# Encrypter

## Explanation
In my CS1440 class, the first assignment was to create this lovely little decryption program written in python that took a file full of these encrypted characters and, based on a specific key, converted them into a proper little sentence. The assignment did provide a small program that would take a string an encrypt a file into the characters for the decrypter, and this program is an attempt to recreate that entirely on my own in C# instead! This will also be helpful in the sense that, my *next* project, is to recreate the 'Decrypter' part in C++. 

The encrypter does the exact inverse of the decrypter (obviously). It takes in a perfectly normal text file, and converts the characters into the special characters thta can be spit out in a text file that can be used in the decrypter. That's really all the program really does. I've included a chart for how the characters get converted for both future readers, and just so I can have something to refer back to.

### Uppercase Characters
| Character      | DuckieCrypt Translation
| :------------- | :---------------------
| `A`            | `^0`
| `B`            | `^1`
| `C`            | `^2`
| `D`            | `^3`
| `E`            | `^4`
| `F`            | `^5`
| `G`            | `^6`
| `H`            | `^7`
| `I`            | `^8`
| `J`            | `^9`
| `K`            | `^10`
| `L`            | `^11`
| `M`            | `^12`
| `N`            | `^13`
| `O`            | `^14`
| `P`            | `^15`
| `Q`            | `^16`
| `R`            | `^17`
| `S`            | `^18`
| `T`            | `^19`
| `U`            | `^20`
| `V`            | `^21`
| `W`            | `^22`
| `X`            | `^23`
| `Y`            | `^24`
| `Z`            | `^25`

### Lowercase Characters
| Character      | DuckieCrypt Translation
| :------------- | :---------------------
| `a`            | `_0`
| `b`            | `_1`
| `c`            | `_2`
| `d`            | `_3`
| `e`            | `_4`
| `f`            | `_5`
| `g`            | `_6`
| `h`            | `_7`
| `i`            | `_8`
| `j`            | `_9`
| `k`            | `_10`
| `l`            | `_11`
| `m`            | `_12`
| `n`            | `_13`
| `o`            | `_14`
| `p`            | `_15`
| `q`            | `_16`
| `r`            | `_17`
| `s`            | `_18`
| `t`            | `_19`
| `u`            | `_20`
| `v`            | `_21`
| `w`            | `_22`
| `x`            | `_23`
| `y`            | `_24`
| `z`            | `_25`

### Special Characters
#### Group A
| Character      | DuckieCrypt Translation
| :------------- | :---------------------
| ` `            | `+A0`
| `!`            | `+A1`
| `"`            | `+A2`
| `#`            | `+A3`
| `$`            | `+A4`
| `%`            | `+A5`
| `&`            | `+A6`
| `'`            | `+A7`
| `(`            | `+A8`
| `)`            | `+A9`
| `*`            | `+A10`
| `+`            | `+A11`
| `,`            | `+A12`
| `-`            | `+A13`
| `.`            | `+A14`
| `/`            | `+A15`
| `0`            | `+A16`
| `1`            | `+A17`
| `2`            | `+A18`
| `3`            | `+A19`
| `4`            | `+A20`
| `5`            | `+A21`
| `6`            | `+A22`
| `7`            | `+A23`
| `8`            | `+A24`
| `9`            | `+A25`
| `:`            | `+A26`
| `;`            | `+A27`
| `<`            | `+A28`
| `=`            | `+A29`
| `>`            | `+A30`
| `?`            | `+A31`
| `@`            | `+A32`

#### Group B
| Character      | DuckieCrypt Translation
| :------------- | :---------------------
| `[`            | `+B0`
| `\`            | `+B1`
| `]`            | `+B2`
| `^`            | `+B3`
| `_`            | `+B4`
| ```            | `+B5`

#### Group C
| Character      | DuckieCrypt Translation
| :------------- | :---------------------
| `{`            | `+C0`
| `\|`           | `+C1`
| `}`            | `+C2`
| `~`            | `+C3`

## Approach
So first things first I need to read the file. That's a bit of an important part. From there I can split the lines up into character arrays, and then input each character into various functions that convert them into the encrypted characters based on their ASCII value. The basic approach for converting each character is: 
- If the ASCII value is between 65 and 90, then that's an uppercase and therefore I can attach a carrot and then the ASCII value minus 65 *(starts at 0 for A, 1 for B, so on). 
- If the ASCII value is between 97 and 122, then that's lowercase and therefore I just attach an underscore, and then the ASCII value minus 97 for the same reason
- If the ASCII value is between 32 and 64, then that's Group A. I just throw a plus and an A, and then the ASCII code minus 32
- If the ASCII value is between 91 and 96, then that's Group B. I just throw a plus and a B, and then the ASCII code minus 91
- If the ASCII value is between 123 and 126, then that's Group C. I throw a plus and a C, and then the ASCII code minus 123.

That's really it. Just read the file, make three methods to take care of those different situations *(that third has to do all three special groups)*, and then write those all to a pretty little file to output! Then I can use that file to read into the C++ Decrypter I make later. Sounds good!

## Pseudocode
### Main
	// User Input
    Ask the user for a valid text file
    Store the name of the file in a string
    Ask the user for the name of the output file
    Store the requested file name in a string
    If that file doesn't have a '.txt' on the end,
        +Tack the filetype on the end

	// Processing
    Attempt to do the following:
        // Text to List
        +Create a list of strings to hold all the encrypted characters
        +Read all the lines of the normal file into a string array
        +For every line in the file,
            -For every character in the given line,
                *Send it to the TypeCheck function, and add the returned string to the string list

        // Output
        +Write every line to a new file with the name the user requested
        +Inform the user that the process was completed.
    If all that fails:
        +Inform the user of what went wrong
	
### TypeCheck
	Define a function to determine which functions to call, that accepts a single character
		Cast the character to it's integer value
		+If the value is between 65 and 90,
			-Return the string given by UpperCase
		+Or, if the value is between 97 and 122,
			-Return the string given by LowerCase
		+Otherwise,
			-Return the string given by SpecialCase

### UpperCase
	Define a function to process the uppercase letter into a encrypted character, and it takes a value
		+Return a carrot plus the (value minus 65)

### LowerCase
	Define a function to process the lowercase letter into a encrypted character, and it takes a value
		+Return an underscore plus the (value minus 97)

### SpecialCase
	Define a function to process the special character into a encrypted character, and it takes a value
		+If it's between 32 and 64,
			-Return a plus sign plus the letter and (value minus 32)
		+Or, if it's between 91 and 96,
			-Return a plus sign plus the letter and (value minus 91)
		+Or, if it's between 123-126,
			-Return a plus sign plus the letter and (value minus 123)
		+Else,
			-Return some indication that it didn't work

## C# Code
### Main
	// User Input
    Console.Write("Enter a valid .txt file: ");
    string decision = Console.ReadLine();
    Console.Write("Enter a name for the output .txt file: ");
    string filename = Console.ReadLine();
    if (!filename.Contains(".txt"))
        filename = filename + ".txt";

    // Processing
    try
    {
        // Text to List
        List<string> cryptList = new List<string>();
        string[] lineArray = System.IO.File.ReadAllLines(decision);
        for (int i = 0; i < lineArray.Length; i++)
            for (int j = 0; j < lineArray[i].Length; j++)
                cryptList.Add(TypeCheck(lineArray[i][j]));

        // Output
        File.WriteAllLines(filename, cryptList);
        Console.WriteLine("Encryption complete! File has been created.");
    }
    catch (FileNotFoundException e)
    {
        Console.WriteLine("Sorry! " + e.Message);
    }
	
### TypeCheck
	static string TypeCheck(char given)
	{
		int value = given;
		if(value >= 65 && value <= 90)
			return UpperCase(value);
		else if (value >= 97 && value <= 122)
			return LowerCase(value);
		else
			return SpecialCase(value);
	}

### UpperCase
	static string UpperCase(int value){
		return "^" + (value - 65); // 65 is the ASCII value of 'A', which has the lowest numerical value the encrypted character can have 
	}

### LowerCase
	static string LowerCase(int value){
		return "_" + (value - 97); // 97 is the ASCII value of 'a', which has the lowest numerical value the encrypted character can have 
	}

### SpecialCase
	static string SpecialCase(int value){
		if (value >= 32 && value <= 64)
			return "+A" + (value - 32); // 32 is the ASCII value of ' ', which has the lowest numerical value the encrypted character can have 
		else if (value >= 91 && value <= 96)
			return "+B" + (value - 91); // 91 is the ASCII value of '[', which has the lowest numerical value the encrypted character can have 
		else if (value >= 123 && value <= 126)
			return "+C" + (value - 91); // 91 is the ASCII value of '{', which has the lowest numerical value the encrypted character can have
		else
			return "???";
		}

## Implementation
Implementation went okay. While the main bulk of the program wasn't anything too difficult, I did meet some decent trouble with the file reading/writing. I have another program that could handle the reading, so that wasn't terribly difficult besides having to wrap it in a try/catch block, which took me a minute to get working *(I tried just putting the file accessing into the block, but it didn't like that too much!)*. It was the rewriting that went wrong.

At least, sort of. The writing to the file actually went just fine! I did realize I'd forgotten the letters for the special characters, but past that it got the encryption just right! The only issue is that it added a newline on the end of each character when it saved each line, and I couldn't quite figure out how to trim those off. There is a `Trim()` function, but that only works for specific strnigs, and all my attempts to just add one line at a time to the file were in vain. Maybe one day I'll figure it out, but for the time being despite all my documenation searching and atempts I couldn't get it to cooperate. Thankfully, I think the decrypter should be just fine if I build it right.


## Testing
From the old assignment, I have two .txt files in a `data` folder that have unencrypted text. While I don't have an encrypted version, I was able to pull up those given text files and the outputted one, and I went through and compared the output with the character sheet above, and there wasn't any issue! So I think for the most part it works just fine. Minus the aforementioned issues, which I suppose I can come back to if I ever figure them out.