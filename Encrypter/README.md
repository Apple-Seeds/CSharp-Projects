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
	Try to do the following:
		+Ask the user for a valid text file
		+Store the name of the file in a string
	If that fails, throw a FileNotFoundException
		+Alert the user that the file wasn't found
	Ask the user for an output name
	Store the output name in a String 
	Create a StreamWriter with appending equaling true

	// Text to List
	Create an integer list that will hold the ASCII values of each character
	Create a string array that holds all the lines of the given file
	For every element in the string array,
		+For each element of the string element,
			-Take each element of the string and add it to the character list

	// Output
	For every element in the string array,
		+Write the returned value of a type check function to the file
	
### TypeCheck
	Define a function to determine which functions to call, that accepts the character list
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

### Specialcase
	Define a function to process the special character into a encrypted character, and it takes a value
		+If it's between 32 and 64,
			-Return a plus sign plus the (value minus 32)
		+Or, if it's between 91 and 96,
			-Return a plus sign plus the (value minus 91)
		+Or, if it's between 123-126,
			-Return a plus sign plus the (value minus 123)
		+Else,
			-Return the character of the given integer value

## C# Code
### Main
	// User Input
	try{
		Console.Write("Enter a valid .txt file: ");
		string decision = Console.ReadLine();
	}
	catch (FileNotFoundException){
		Console.WriteLine("The file wasn't able to be found. Try again.");
	}
	Console.Write("Enter a name for the output .txt file: ")
	string filename = Console.ReadLine();
	using StreamWriter file = new(filename, append: true);

	// Text to List
	List<int> ASCIIList = new List<int>();
	string[] lineArray = System.IO.File.ReadAllLines(decision);
	for (int i = 0; i < lineArray.Length; i++)
		for (int j = 0; j < lineArray[i].Length; j++)
			ASCIIList.Add(lineArray[i][j]);

	// Output
	for (int i = 0; i < ASCIIList.Count; i++)
		await file.WriteAsync(TypeCheck(ASCIIList[i]));
	
### TypeCheck
	static string TypeCheck(int value)
	{
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

### Specialcase
	static string SpecialCase(int value){
		if (value >= 32 && value <= 64)
			return "+" + (value - 32); // 32 is the ASCII value of ' ', which has the lowest numerical value the encrypted character can have 
		else if ()
			-Return a plus sign plus the (value minus 91)
		+Or, if it's between 123-126,
			-Return a plus sign plus the (value minus 123)
		+Else,
			-Return the character of the given integer value
		}