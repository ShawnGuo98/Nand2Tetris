//push constant 10
@10
D=A
@256
M=D
@0
M=M+1

//pop local 0
@0
D=A
@1
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

//push constant 21
@21
D=A
@256
M=D
@0
M=M+1

//push constant 22
@22
D=A
@257
M=D
@0
M=M+1

//pop argument 2
@2
D=A
@2
D=D+M
@T1
M=D
@257
D=M
@T1
A=M
M=D
@0
M=M-1

//pop argument 1
@1
D=A
@2
D=D+M
@T2
M=D
@256
D=M
@T2
A=M
M=D
@0
M=M-1

//push constant 36
@36
D=A
@256
M=D
@0
M=M+1

//pop this 6
@6
D=A
@3
D=D+M
@T3
M=D
@256
D=M
@T3
A=M
M=D
@0
M=M-1

//push constant 42
@42
D=A
@256
M=D
@0
M=M+1

//push constant 45
@45
D=A
@257
M=D
@0
M=M+1

//pop that 5
@5
D=A
@4
D=D+M
@T4
M=D
@257
D=M
@T4
A=M
M=D
@0
M=M-1

//pop that 2
@2
D=A
@4
D=D+M
@T5
M=D
@256
D=M
@T5
A=M
M=D
@0
M=M-1

//push constant 510
@510
D=A
@256
M=D
@0
M=M+1

//pop temp 6
@256
D=M
@11
M=D
@0
M=M-1

//push local 0
@0
D=A
@1
A=D+M
D=M
@256
M=D
@0
M=M+1

//push that 5
@5
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

//push argument 1
@1
D=A
@2
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

//push this 6
@6
D=A
@3
A=D+M
D=M
@257
M=D
@0
M=M+1

//push this 6
@6
D=A
@3
A=D+M
D=M
@258
M=D
@0
M=M+1

//add
@257
D=M
@258
D=D+M
@257
M=D
@0
M=M-1

//sub
@256
D=M
@257
D=D-M
@256
M=D
@0
M=M-1

//push temp 6
@11
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

