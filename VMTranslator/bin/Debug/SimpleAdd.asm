//push constant 7
@7
D=A
@256
M=D
@0
M=M+1

//push constant 8
@8
D=A
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

