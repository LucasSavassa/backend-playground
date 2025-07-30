// Runs an infinite loop that listens to the keyboard input. 
// When a key is pressed (any key), the program blackens the screen,
// i.e. writes "black" in every pixel. When no key is pressed, 
// the screen should be cleared.
(LOOP)
    @SCREEN //SET POINTER = SCREEN
    D=A     //SET POINTER = SCREEN
    @16383  //SET POINTER = SCREEN
    M=D     //SET POINTER = SCREEN

    @KBD    //READ KBD
    D=M     //READ KBD

    @BLACK  //GO TO BLACK IF KEY PRESSED
    D;JGT   //GO TO BLACK IF KEY PRESSED

    @WHITE  //GO TO WHITE IF KEY NOT PRESSED
    D;JEQ   //GO TO WHITE IF KEY NOT PRESSED

(BLACK)
    @R0
    M=-1
    @FOREACH
    0;JMP

(WHITE)
    @R0
    M=0
    @FOREACH
    0;JMP

(FOREACH)
    @KBD    //BREAK IF
    D=A   //BREAK IF
    @16383  //BREAK IF
    D=D-M   //BREAK IF
    @LOOP   //BREAK IF
    D;JLE   //BREAK IF

    @R0         //GET NEW VALUE
    D=M         //GET NEW VALUE

    @16383      //GET POINTER
    A=M         //GET POINTER

    M=D         //SET NEW VALUE

    @16383      //SET POINTER
    M=M+1       //SET POINTER
    
    @FOREACH    //CONTINUE
    0;JMP       //CONTINUE
