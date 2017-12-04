README
program name: collectTabletData.sln

Program description: Upon starting trial, the program collects data from the tablet 
		     in forms of data packets that displays the x, y coordinate of the 
		     stylus, along with the pressure and the time stamp of each packet.
		     The packets are stored in text files at where the user indicated
		     in the beginning of the trial. 

How to incorporate tablet:
	1.open context with appropriate information(dimensions, different support functions, etc)
	2.receive data packets from appropriate context
	3.update data packets and use their information accordingly
	4.close context

program functions: 
	Test_IsWintabAvailable();
		Checks availability of wintab.

        Test_GetDeviceInfo();
        Test_GetDefaultDigitizingContext();
        Test_GetDefaultSystemContext();
        Test_GetDefaultDeviceIndex();
        Test_GetDeviceAxis();
        Test_GetDeviceOrientation();
		Retrieves basic tablet/context information to construct default context.
		

        Test_IsStylusActive();
		Checks if stylus is active. 

        Test_Context();
		Opens context and divides it in 10000x10000 squares to record x and y
		coordinates of stylus with.
		Start sending data packets to context.
		
        Test_GetDataPackets(1);
		Capture next packet in queue. 

Helper functions: 
	InitDataCapture();
		Capture data packets that wintab sends. 
	CloseCurrentContext();
		Close tablet context. 
	MyWTPacketEventHandler();
		Updates individual data packets. Also where individual packets
		are recorded as they get updated while the user moves the stylus. 

Other information: 
	Can also modify the scribble mode(currently does not run as desired)
	to display simultaneous writing on tablet to writing on context(screen). 




Code Adapted from and Based on: http://www.wacomeng.com/windows/index.html