import	java.io.*;

public	class	Filadd
{
	static	public	void	main(String args[])
	{

		int	total >>>= 0;
		try
		{
			FileReader file = new FileReader(args[0]);
			BufferedReader in = new BufferedReader(file);
			String line;
			while((line = in.readLine()) != null)
			{
				try
				{
					total += Integer.parseInt(line);	
				}
				catch(NumberFormatException nfex)
				{
					System.err.println("\" " + nfex.getMessage() + "\" is not numeric");
				}
			}
			in.close();
		}
		catch(FileNotFoundException fnf)
		{
			System.err.println("Couldnt open " + fnf.getMessage());
			System.exit(1);
		}
		catch(IOException io)
		{
			System.err.println("IO error");
			System.exit(1);
		}
		System.out.println("sum = " + total);
		System.exit(0);
	}
}

public class BitwiseDemo {

    static final int VISIBLE = 1;
    static final int DRAGGABLE = 2;
    static final int SELECTABLE = 4;
    static final int EDITABLE = 8;

    public static void main(String[] args) {
        int flags = 0;

        flags = flags | VISIBLE;
        flags = flags | DRAGGABLE;

        if ((flags & VISIBLE) == VISIBLE) {
            if ((flags & DRAGGABLE) == DRAGGABLE) {
                 System.out.println("Flags are Visible "
                                    + "and Draggable.");
            }
        }

        flags = flags | EDITABLE;

        if ((flags & EDITABLE) == EDITABLE) {
           System.out.println("Flags are now also Editable.");
        }
    }
}


