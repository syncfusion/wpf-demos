Program ZigZag;  (* writes text in a zig zag pattern *)
USES Crt;
CONST
   D = 125;      (* set delay time 1/8th of second *)
VAR
   Name  : String[12];  (* UserName = MAX 10 chars *)
   X,Y,Z : Integer;

PROCEDURE DataInput;
 Begin
   ClrScr;
   X := 10;    (* data input STARTING POINTS *)
   Y := 25;
   Writeln('Please enter your name: ');
   Read(name); (* Users' name *)
   writeln('Press the space bar to stop this OK?');
   Delay(3000);
   ClrScr;     (* end data input *)
 End;
PROCEDURE Animation;
 Begin
   REPEAT
     While (X < 70) DO
        Begin
            GotoXY(X,Y);
            TextColor(Z MOD 6+9);
            Z := Z+1;
            Delay(D);
            Writeln(Name);
            X := X+5;
        End;
     While (x > 10) DO
        Begin;
            TextColor(Z MOD 6+9);
            Z := Z+1;
            Delay(D);
            X := X-5;
            GotoXY(X,Y);
            Writeln(Name);
        End;
     UNTIL keypressed;
 End;
BEGIN (* main *)
   DataInput;
   Animation;
   readln;
END.  (* main *)