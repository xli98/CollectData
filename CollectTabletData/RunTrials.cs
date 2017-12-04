using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using WintabDN;
using System.Diagnostics;

//TODO: throw error at appropriate places
namespace CollectTabletData
{

    public partial class RunTrials : Form
    {
        private Int32 numOfTrial = 1;

        private CWintabContext m_logContext = null;
        private CWintabData m_wtData = null;
        private UInt32 m_maxPkts;// = 1;   // max num pkts to capture/display at a time

        //collect data: x, y, pressure, time stamp 
        private Int64 m_pkX = 0;
        private Int64 m_pkY = 0;
        private UInt32 m_pressure = 0;
        private long m_pkTime = 0;
        private long m_pkTimeLast = 0;
        private long m_timeStart = 0; //TODO: probably added sometimes
        private UInt64 m_serialNumber = 0;
        private int called = 0;
        //private UInt32 m_leaveQueueTime = 0;

        private Point m_lastPoint = Point.Empty;
        private Graphics m_graphics;
        private Pen m_pen;
        //private Pen m_backPen;

        // These constants can be used to force Wintab X/Y data to map into a
        // a 10000 x 10000 grid, as an example of mapping tablet data to values
        // that make sense for your application.
        //TODO: set context of tablet to match boarder of form
        private const Int32 m_TABEXTX = 10000;
        private const Int32 m_TABEXTY = 10000;

        string DataFolder;
        string DataFileBase;

        public RunTrials(string FolderName, string DataSetName)
        {
            InitializeComponent();
            DataFileBase = DataSetName;
            DataFolder = FolderName;
        }

        public HCTX HLogContext { get { return m_logContext.HCtx; } }

        private void Test_IsWintabAvailable()
        {
            if (!CWintabInfo.IsWintabAvailable())
            {
                throw new Exception("Wintab was not found!\nCheck to see if tablet driver service is running.\n");
            }
        }

        private void Test_GetDeviceInfo()
        {
            string devInfo = CWintabInfo.GetDeviceInfo();
        }

        private void Test_GetDefaultDigitizingContext()
        {
            CWintabContext context = CWintabInfo.GetDefaultDigitizingContext();

        }

        private void Test_GetDefaultSystemContext()
        {
            CWintabContext context = CWintabInfo.GetDefaultSystemContext();
        }

        private void Test_GetDefaultDeviceIndex()
        {
            Int32 devIndex = CWintabInfo.GetDefaultDeviceIndex();

            //TODO: throw error/exception
            //TraceMsg("Default device index is: " + devIndex + (devIndex == -1 ? " (virtual device)\n" : "\n"));
        }

        private void Test_GetDeviceAxis()
        {
            WintabAxis axis;

            // Get virtual device axis for X, Y and Z.
            axis = CWintabInfo.GetDeviceAxis(-1, EAxisDimension.AXIS_X);

            //TraceMsg("Device axis X for virtual device:\n");
            //TraceMsg("\taxMin, axMax, axUnits, axResolution: " + axis.axMin + "," + axis.axMax + "," + axis.axUnits + "," + axis.axResolution.ToString() + "\n");

            axis = CWintabInfo.GetDeviceAxis(-1, EAxisDimension.AXIS_Y);
            //TraceMsg("Device axis Y for virtual device:\n");
            //TraceMsg("\taxMin, axMax, axUnits, axResolution: " + axis.axMin + "," + axis.axMax + "," + axis.axUnits + "," + axis.axResolution.ToString() + "\n");

            axis = CWintabInfo.GetDeviceAxis(-1, EAxisDimension.AXIS_Z);
            //TraceMsg("Device axis Z for virtual device:\n");
            //TraceMsg("\taxMin, axMax, axUnits, axResolution: " + axis.axMin + "," + axis.axMax + "," + axis.axUnits + "," + axis.axResolution.ToString() + "\n");
        }

        private void Test_GetDeviceOrientation()
        {
            bool tiltSupported = false;
            WintabAxisArray axisArray = CWintabInfo.GetDeviceOrientation(out tiltSupported);
        }

        private void Test_IsStylusActive()
        {
            bool isStylusActive = CWintabInfo.IsStylusActive();
            if (isStylusActive == false)
            {
                throw new Exception("Stylus is not active!");
            }
        }

        //TODO: modify this to fit screen window
        private void Test_Context()
        {
            bool status = false;
            CWintabContext logContext = null;

            try
            {
                logContext = OpenTestDigitizerContext();
                if (logContext == null)
                {
                    //TODO: throw error maybe? 
                    throw new Exception("Test_Context: FAILED OpenTestDigitizerContext - bailing out...\n");
                }

                status = logContext.Enable(true);
                //TraceMsg("Context Enable: " + (status ? "PASSED" : "FAILED") + "\n");

                status = logContext.SetOverlapOrder(false);
                //TraceMsg("Context SetOverlapOrder to bottom: " + (status ? "PASSED" : "FAILED") + "\n");
                status = logContext.SetOverlapOrder(true);
                //TraceMsg("Context SetOverlapOrder to top: " + (status ? "PASSED" : "FAILED") + "\n");
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
            finally
            {
                //TODO: throw exception
                //if (logContext != null)
                //{
                //    status = logContext.Close();
                //    TraceMsg("Context Close: " + (status ? "PASSED" : "FAILED") + "\n");
                //}
            }
        }

        private CWintabContext OpenTestDigitizerContext(
            int width_I = m_TABEXTX, int height_I = m_TABEXTY, bool ctrlSysCursor = true)
        {
            bool status = false;
            CWintabContext logContext = null;

            try
            {
                // Get the default digitizing context.
                // Default is to receive data events.
                logContext = CWintabInfo.GetDefaultDigitizingContext(ECTXOptionValues.CXO_MESSAGES);

                // Set system cursor if caller wants it.
                if (ctrlSysCursor)
                {
                    logContext.Options |= (uint)ECTXOptionValues.CXO_SYSTEM;
                }

                if (logContext == null)
                {
                    //TraceMsg("FAILED to get default digitizing context.\n");
                    return null;
                }

                // Modify the digitizing region.
                logContext.Name = "WintabDN Event Data Context";

                // output in a grid of the specified dimensions.
                logContext.OutOrgX = logContext.OutOrgY = 0;
                logContext.OutExtX = scribblePanel.Width;//width_I;
                logContext.OutExtY = scribblePanel.Height;//height_I;


                // Open the context, which will also tell Wintab to send data packets.
                status = logContext.Open();

                //TraceMsg("Context Open: " + (status ? "PASSED [ctx=" + logContext.HCtx + "]" : "FAILED") + "\n");
            }
            catch (Exception ex)
            {
                throw new Exception("OpenTestDigitizerContext ERROR: " + ex.ToString());
            }

            return logContext;
        }

        private CWintabContext OpenTestSystemContext(
            int width_I = m_TABEXTX, int height_I = m_TABEXTY, bool ctrlSysCursor = true)
        {
            bool status = false;
            CWintabContext logContext = null;

            try
            {
                // Get the default system context.
                // Default is to receive data events.
                //logContext = CWintabInfo.GetDefaultDigitizingContext(ECTXOptionValues.CXO_MESSAGES);
                logContext = CWintabInfo.GetDefaultSystemContext(ECTXOptionValues.CXO_MESSAGES);
                // Set system cursor if caller wants it.
                if (ctrlSysCursor)
                {
                    logContext.Options |= (uint)ECTXOptionValues.CXO_SYSTEM;
                }
                else
                {
                    logContext.Options &= ~(uint)ECTXOptionValues.CXO_SYSTEM;
                }

                if (logContext == null)
                {
                    //TraceMsg("FAILED to get default digitizing context.\n");
                    return null;
                }

                // Modify the digitizing region.
                logContext.Name = "WintabDN Event Data Context";

                WintabAxis tabletX = CWintabInfo.GetTabletAxis(EAxisDimension.AXIS_X);
                WintabAxis tabletY = CWintabInfo.GetTabletAxis(EAxisDimension.AXIS_Y);

                logContext.InOrgX = 0;
                logContext.InOrgY = 0;
                logContext.InExtX = tabletX.axMax;
                logContext.InExtY = tabletY.axMax;

                // SetSystemExtents() is (almost) a NO-OP redundant if you opened a system context.
                SetSystemExtents(ref logContext);

                // Open the context, which will also tell Wintab to send data packets.
                status = logContext.Open();
                //TODO: look at if this is where data captures

                //TraceMsg("Context Open: " + (status ? "PASSED [ctx=" + logContext.HCtx + "]" : "FAILED") + "\n");
            }
            catch (Exception ex)
            {
                throw new Exception("OpenTestDigitizerContext ERROR: " + ex.ToString());
            }

            return logContext;
        }

        private void Test_DataPacketQueueSize()
        {
            bool status = false;
            UInt32 numPackets = 0;
            CWintabContext logContext = null;

            try
            {
                logContext = OpenTestDigitizerContext();

                if (logContext == null)
                {
                    //TraceMsg("Test_DataPacketQueueSize: FAILED OpenTestDigitizerContext - bailing out...\n");
                    return;
                }

                CWintabData wtData = new CWintabData(logContext);
                if (wtData == null)
                {
                    throw new Exception("Could not create CWintabData object.");
                }

                numPackets = wtData.GetPacketQueueSize();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
            finally
            {
                if (logContext != null)
                {
                    status = logContext.Close();
                    //TraceMsg("Context Close: " + (status ? "PASSED" : "FAILED") + "\n");
                }
            }
        }

        private void Test_GetDataPackets(UInt32 maxNumPkts_I)
        {
            // Set up to capture/display maxNumPkts_I packet at a time.
            m_maxPkts = maxNumPkts_I;

            // Open a context and try to capture pen data.
            InitDataCapture();
        }


        ///////////////////////////////////////////////////////////////////////
        // Helper functions
        ///////////////////////////////////////////////////////////////////////
        private void InitDataCapture(
                int ctxWidth_I = m_TABEXTX, int ctxHeight_I = m_TABEXTY, bool ctrlSysCursor_I = true)
        {
            try
            {
                // Close context from any previous test.
                CloseCurrentContext();

                //TraceMsg("Opening context...\n");

                m_logContext = OpenTestSystemContext(ctxWidth_I, ctxHeight_I, ctrlSysCursor_I);

                if (m_logContext == null)
                {
                    //TraceMsg("Test_DataPacketQueueSize: FAILED OpenTestSystemContext - bailing out...\n");
                    return;
                }

                // Create a data object and set its WT_PACKET handler.
                m_wtData = new CWintabData(m_logContext);
                m_wtData.SetWTPacketEventHandler(MyWTPacketEventHandler);
                m_timeStart = Stopwatch.GetTimestamp(); //DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                called++;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
        }

        private void CloseCurrentContext()
        {
            try
            {
                //TraceMsg("Closing context...\n");
                if (m_logContext != null)
                {
                    m_logContext.Close();
                    m_logContext = null;
                    m_wtData = null;
                }

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
        }

        private void computeTimeDif()
        {
            // compute inter - sample intervals
            //   GetSecISI = diff(pktData(:,GetSecCol));
            //compute mean inter-sample interval
            // IntSampInt = 1000 * mean(GetSecISI);

            //check whether maximum inter - sample interval is too long
            //indicating that user took pen out of range during sampling
            //compute mean without max value
            //meanWoMax = (sum(GetSecISI) - max(GetSecISI)) / (nPts - 1);
            //if max(GetSecISI) > 2 * meanWoMax
            //max interval too long: more than double the mean when
            //max value removed
            //    fprintf(1, '\n\tUnexpected data values.\n');
            //fprintf(1, '\tPen was probably lifted from tablet during data collection\n');
            //fprintf(1, '\tBe sure to keep pen tip in contact with tablet\n');
            //done = false;
            //end


            //if done
            //calculate inter - sample interval reported by tablet
            //    timeStampISI = diff(pktData(:, timeStampCol));
            //firstDrawPt = find(pktData(:, pressCol), 1, 'first');
            //lastDrawPt = find(pktData(:, pressCol), 1, 'last');
            //meanTimeStampISI = mean(timeStampISI(firstDrawPt: lastDrawPt - 1));
            //end
        }

        private void SetSystemExtents(ref CWintabContext logContext)
        {
            //Rectangle rect = new Rectangle(int.MaxValue, int.MaxValue, int.MinValue, int.MinValue);

            foreach (Screen screen in Screen.AllScreens) 
                //rect = Rectangle.Union(rect, screen.Bounds);

            logContext.OutOrgX = scribblePanel.Left;//rect.Left;
            logContext.OutOrgY = scribblePanel.Top;//rect.Top;
            logContext.OutExtX = scribblePanel.Width;//rect.Width;
            logContext.OutExtY = scribblePanel.Height; //rect.Height;

            // In Wintab, the tablet origin is lower left.  Move origin to upper left
            // so that it coincides with screen origin.
            logContext.OutExtY = -logContext.OutExtY;
        }

        public void MyWTPacketEventHandler(Object sender_I, MessageReceivedEventArgs eventArgs_I)
        {
            //System.Diagnostics.Debug.WriteLine("Received WT_PACKET event");
            if (m_wtData == null)
            {
                return;
            }

            try
            {
                if (m_maxPkts == 1)
                {
                    uint pktID = (uint)eventArgs_I.Message.WParam;
                    WintabPacket pkt = m_wtData.GetDataPacket((uint)eventArgs_I.Message.LParam, pktID);
                    //DEPRECATED WintabPacket pkt = m_wtData.GetDataPacket(pktID);

                    if (pkt.pkContext != 0)
                    {
                        m_pkX = pkt.pkX;
                        m_pkY = pkt.pkY;
                        m_pkTime = pkt.PKrealTime;
                        m_pressure = pkt.pkNormalPressure;
                        m_serialNumber = pkt.pkSerialNumber;


                        //TODO: time and pressure are UINT- think about how to not convert that - also something about minuses
                        int col;
                        ArrayList dataMat = new ArrayList();
                        dataMat.Add(m_serialNumber);
                        dataMat.Add(m_pkX);
                        dataMat.Add(m_pkY);
                        dataMat.Add(m_pressure);
                        dataMat.Add(m_pkTime.ToString());// - m_pkTimeLast);
                        dataMat.Add(called);
                        //dataMat.Add(pkt.pkStatus);
                        //long[] dataMat = new long[] { curpoint, m_pkX, m_pkY, m_pressure, m_pkTime };

                        //TODO: update the trial numbers
                        //int trialNum = 1;
                        string dataFileName = Path.Combine(DataFolder, DataFileBase) + "_Trial_" + Convert.ToString(numOfTrial) + ".txt";

                        //long ticks = DateTime.UtcNow.Ticks - DateTime.Parse("01/01/1970 00:00:00").Ticks;
                        //ticks /= 10000000; //Convert windows ticks to seconds
                        //String timeStamp = ticks.ToString();

                        using (StreamWriter dataFile =
                        new StreamWriter(dataFileName, true))
                        {
                            for (col = 0; col < 6; ++col)
                            {
                                dataFile.Write("{0:d4}\t", dataMat[col]);
                            }
                            dataFile.WriteLine();
                        }

                        m_pkTimeLast = m_pkTime;

                        // enable scribbling on screen
                        //with packets one at a time
                        if (m_graphics == null){
                        }else {
                                // scribble mode
                                int clientWidth = scribblePanel.Width;
                                int clientHeight = scribblePanel.Height;

                                // m_pkX and m_pkY are in screen (system) coordinates.

                                Point clientPoint = scribblePanel.PointToClient(new Point((int)m_pkX, (int)m_pkY));
                                //Trace.WriteLine("CLIENT:   X: " + clientPoint.X + ", Y:" + clientPoint.Y);

                                if (m_lastPoint.Equals(Point.Empty))
                                {
                                    m_lastPoint = clientPoint;
                                    m_pkTimeLast = m_pkTime;
                                }

                                m_pen.Width = (float)(m_pressure / 200);

                                if (m_pressure > 0)
                                {
                                m_graphics.DrawLine(m_pen, clientPoint, m_lastPoint);
                            }

                                m_lastPoint = clientPoint;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("FAILED to get packet data: " + ex.ToString());
            }
        }

        private void existentFiles(String DataFolder, String DataFileBase)
        {
            int existentFiles = 0;
            string[] fileArray = Directory.GetFiles(DataFolder, "*.txt");
            foreach(string str in fileArray)
            {
                if(str.Substring(0, DataFileBase.Length).Equals(DataFileBase))
                {
                    existentFiles++; 
                }
            }

            //foreach (string file in Directory.EnumerateFiles(DataFolder, "*.txt"))
            //{
            //string contents = File.ReadAllText(file);
            //}
            numOfTrial += existentFiles;
        }

        private void Enable_Scribble(bool enable = false)
        {
            if (enable)
            {
                // Set up to capture 1 packet at a time.
                m_maxPkts = 1;

                // Init scribble graphics.
                //m_graphics = CreateGraphics();

                m_graphics = scribblePanel.CreateGraphics();

                m_pen = new Pen(Color.Black);
                //m_backPen = new Pen(Color.White);
                // You should now be able to scribble in the scribblePanel.
            }
            else
            {
                // Remove scribble context.
                CloseCurrentContext();

                // Turn off graphics.
                if (m_graphics != null)
                {
                    scribblePanel.Invalidate();
                    m_graphics = null;
                }

            }
        }

        //private void scribblePanel_Resize(object sender, EventArgs e)
        //{
        //    if (m_graphics != null)
        //    {
        //        m_graphics.Dispose();
        //        m_graphics = scribblePanel.CreateGraphics();
        //        m_graphics.SmoothingMode = SmoothingMode.AntiAlias;
        //    }
        //}

        private void RunTrials_Load(object sender, EventArgs e){
        }

        private void btnStartTrial_Click(object sender, EventArgs e)
        {
            btnReturnToMain.Enabled = false;
            btnStartTrial.Enabled = false;

            bool controlSystemCursor = true;

            // Open a context and try to capture pen data;
            InitDataCapture(m_TABEXTX, m_TABEXTY, controlSystemCursor);
            Enable_Scribble(true);

            //Test_IsWintabAvailable();
            //Test_GetDeviceInfo();
            //Test_GetDefaultDigitizingContext();
            //Test_GetDefaultSystemContext();
            //Test_GetDefaultDeviceIndex();
            //Test_GetDeviceAxis();
            //Test_GetDeviceOrientation();
            //Test_IsStylusActive();
            //Test_Context();
            //Test_DataPacketQueueSize();
            //Test_GetDataPackets(1);
            existentFiles(DataFileBase, DataFileBase);

            string dataFileName = Path.Combine(DataFolder, DataFileBase) + "_Trial_" + Convert.ToString(numOfTrial) + ".txt";
            using (StreamWriter dataFile =
                       new StreamWriter(dataFileName, true))
            {
                String[] dataMat = new String[] { "Pt", "x", "y", "Pressure", "InterPtMs", "Called" };
                for (int i = 0; i < dataMat.Length; i++) {
                    dataFile.Write("{0:d4}\t", dataMat[i]);
                }
                dataFile.WriteLine();
            }
        }

        private void btnEndTrial_Click(object sender, EventArgs e)
        {
            btnStartTrial.Enabled = true;
            btnReturnToMain.Enabled = true;
            scribblePanel.Enabled = true;


            scribblePanel.Invalidate();
            Enable_Scribble(false);

            CloseCurrentContext();
            numOfTrial++;
            //int nDataCols = 4;

            //using (StreamWriter dataFile =
            //new StreamWriter(dataFileName, true))
            //{
            //    for (pt = 0; pt < nDataPts; pt++)
            //    {
            //        for (col = 0; col < nDataCols; col++)
            //        {
            //            dataFile.Write("{0:d4}\t",dataMat[pt,col]);
            //        }
            //        dataFile.WriteLine();

            //    }
            //}

        }

        private void btnReturnToMain_Click(object sender, EventArgs e)
        {
            //TODO figure out whether should close or just make not visible
            // this.Visible = false;
            this.Close();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }
    }
}
