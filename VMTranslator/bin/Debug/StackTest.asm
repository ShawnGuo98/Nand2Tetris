//push constant 17
@17
D=A
@256
M=D
@0
M=M+1

//push constant 17
@17
D=A
@257
M=D
@0
M=M+1

//eq
@256
D=M
@257
D=D-M
@EQ0
D;JEQ
@256
M=0
@EQEND0
0;JMP
(EQ0)
@256
M=-1
(EQEND0)
@0
M=M-1

//push constant 17
@17
D=A
@257
M=D
@0
M=M+1

//push constant 16
@16
D=A
@258
M=D
@0
M=M+1

//eq
@257
D=M
@258
D=D-M
@EQ1
D;JEQ
@257
M=0
@EQEND1
0;JMP
(EQ1)
@257
M=-1
(EQEND1)
@0
M=M-1

//push constant 16
@16
D=A
@258
M=D
@0
M=M+1

//push constant 17
@17
D=A
@259
M=D
@0
M=M+1

//eq
@258
D=M
@259
D=D-M
@EQ2
D;JEQ
@258
M=0
@EQEND2
0;JMP
(EQ2)
@258
M=-1
(EQEND2)
@0
M=M-1

//push constant 892
@892
D=A
@259
M=D
@0
M=M+1

//push constant 891
@891
D=A
@260
M=D
@0
M=M+1

//lt
@259
D=M
@260
D=D-M
@LT3
D;JLT
@259
M=0
@LTEND3
0;JMP
(LT3)
@259
M=-1
(LTEND3)
@0
M=M-1

//push constant 891
@891
D=A
@260
M=D
@0
M=M+1

//push constant 892
@892
D=A
@261
M=D
@0
M=M+1

//lt
@260
D=M
@261
D=D-M
@LT4
D;JLT
@260
M=0
@LTEND4
0;JMP
(LT4)
@260
M=-1
(LTEND4)
@0
M=M-1

//push constant 891
@891
D=A
@261
M=D
@0
M=M+1

//push constant 891
@891
D=A
@262
M=D
@0
M=M+1

//lt
@261
D=M
@262
D=D-M
@LT5
D;JLT
@261
M=0
@LTEND5
0;JMP
(LT5)
@261
M=-1
(LTEND5)
@0
M=M-1

//push constant 32767
@32767
D=A
@262
M=D
@0
M=M+1

//push constant 32766
@32766
D=A
@263
M=D
@0
M=M+1

//gt
@262
D=M
@263
D=D-M
@GT6
D;JGT
@262
M=0
@GTEND6
0;JMP
(GT6)
@262
M=-1
(GTEND6)
@0
M=M-1

//push constant 32766
@32766
D=A
@263
M=D
@0
M=M+1

//push constant 32767
@32767
D=A
@264
M=D
@0
M=M+1

//gt
@263
D=M
@264
D=D-M
@GT7
D;JGT
@263
M=0
@GTEND7
0;JMP
(GT7)
@263
M=-1
(GTEND7)
@0
M=M-1

//push constant 32766
@32766
D=A
@264
M=D
@0
M=M+1

//push constant 32766
@32766
D=A
@265
M=D
@0
M=M+1

//gt
@264
D=M
@265
D=D-M
@GT8
D;JGT
@264
M=0
@GTEND8
0;JMP
(GT8)
@264
M=-1
(GTEND8)
@0
M=M-1

//push constant 57
@57
D=A
@265
M=D
@0
M=M+1

//push constant 31
@31
D=A
@266
M=D
@0
M=M+1

//push constant 53
@53
D=A
@267
M=D
@0
M=M+1

//add
@266
D=M
@267
D=D+M
@266
M=D
@0
M=M-1

//push constant 112
@112
D=A
@267
M=D
@0
M=M+1

//sub
@266
D=M
@267
D=D-M
@266
M=D
@0
M=M-1

//neg
@266
M=-M

//and
@265
D=M
@266
D=D&M
@265
M=D
@0
M=M-1

//push constant 82
@82
D=A
@266
M=D
@0
M=M+1

//or
@265
D=M
@266
D=D|M
@265
M=D
@0
M=M-1

//not
@265
M=!M

