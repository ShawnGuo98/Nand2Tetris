//push constant 3030
@3030
D=A
@256
M=D
@0
M=M+1

//pop pointer 0
@256
D=M
@3
M=D
@0
M=M-1

//push constant 3040
@3040
D=A
@256
M=D
@0
M=M+1

//pop pointer 1
@256
D=M
@4
M=D
@0
M=M-1

//push constant 32
@32
D=A
@256
M=D
@0
M=M+1

//pop this 2
@2
D=A
@3
D=D+M
@T0
M=D
@256
D=M
@T0
A=M
M=D
@0
M=M-1

//push constant 46
@46
D=A
@256
M=D
@0
M=M+1

//pop that 6
@6
D=A
@4
D=D+M
@T1
M=D
@256
D=M
@T1
A=M
M=D
@0
M=M-1

//push pointer 0
@3
D=M
@256
M=D
@0
M=M+1

//push pointer 1
@4
D=M
@257
M=D
@0
M=M+1

//add
@256
D=M
@257
D=D+M
@256
M=D
@0
M=M-1

//push this 2
@2
D=A
@3
A=D+M
D=M
@257
M=D
@0
M=M+1

//sub
@256
D=M
@257
D=D-M
@256
M=D
@0
M=M-1

//push that 6
@6
D=A
@4
A=D+M
D=M
@257
M=D
@0
M=M+1

//add
@256
D=M
@257
D=D+M
@256
M=D
@0
M=M-1

