# Largest Product

## Explanation
Largest Product is this fun little program where I'm given a very *large* number. I take this number and multiply adjacent digits together to find out which set of digits has the largest product. For example, if this big number has four nines in a row, then the largest product of four adjacent digits would be 9x9x9x9, which is 6561. The site I got it from probably explains it much better: https://projecteuler.net/problem=8

## Approach
So there's two aspects to this program. There's getting the individual digits from the big number and putting it into a list, and then there's searching that list to find the big product. That second part isn't really the issue, it's pretty similar to a sorting algorithm really. Just take the products of four/thirteen digits, increment by one, and if *that* product is bigger, save that one. Otherwise, just don't. It's that list creation which is a tizzy.

My initial approach used this idea of using modulus to get the numbers, but I ran into a difficult issue that there is literally *not a data type that holds a 1000 digit number*. However this seems to work a little in my favor, as my workaround for this is to use the one data type that has no character limit: just a boring text file. I don't actually remember how to read files in C#, but I'm not terribly worried about figuring that one out. 

But, once I get that file opened with the big number inside of it, theoretically it shouldn't be too hard to read just one character out at a time, convert it to an integer *(or even a smaller data type)*, and then save that into a list. That's much easier than the math approach for smaller numbers *(not that that was terribly complex anyway, of course)*, so hopefully that all goes well. My approach to getting the data might be a bit memory heavy, and I'm sure there's optimizations that could be made, but at the end of the day I'm doing this to demonstrate how I would do things. Not the *best* way to do things. 

Of course, ideally those would be the same, but alas.

## Psuedocode
	// User Input
	Ask the user for a file
	Get the name of that file

	// Digit Parsing
	Create a list to hold the digits
    Add all the lines of the file into an array
    Create a list to hold the character arrays for each line
    For every line in the array of lines,
        +Turn the line into an array of characters, and add that array into the list
        +For each character in each character array in the list,          
            -Turn the character into an integer and add it to the digit list

	// Product Solving
	Set the four-product variable to the result of the function that does all the math
	Set the thirteen-product variable to the result of the function that does all the math

	/// Four-Product
	Set aside a variable to hold the four-product
	Loop the length of the list minus 4,
		+Set a placeholder to be the value of the digit in the list at the incrementation variable's point, multiplied by the following three digits
		+If that value is greater than the four-product variable
			-Set the four-product to that placeholder
	/// Thirteen-Product
	Set aside a variable to hold the thirteen-product
	Loop the length of the list minus 13,
		+Set a placeholder to be the value of the digit in the list at the incrementation variable's point, multiplied by the following twelve digits
		+If that value is greater than the four-product variable
			-Set the thirteen-product to that placeholder

	// Output
	Tell the user the value of the four-product
	Tell the user the value of the thirteen-product
### ParseProduct
	ParseProduct is called, and is given both a list and a counting variable
        Set a long variable for the placeholder
        Set a long variable as the product
        For each element of the given list, minus the counting variable,
            +Set the placeholder to be the first value
            +For each of the subsequent values, based on the counting variable,
                -Multiply the placeholder by the next upcoming value
            +If the placeholder value turns out to be greater than the product,
                -Set the product variable to be the placeholder
        Return the product

## C# Code
### Main
	// User Input
	Console.Write("Enter a valid .txt file: ");
	string decision = Console.ReadLine();

	// Digit Parsing
	List<int> digitList = new List<int>();
    string[] lineArray = System.IO.File.ReadAllLines(decision);
    List<char[]> charList = new List<char[]>();
    for (int i = 0; i < lineArray.Length; i++)
    {
        charList.Add(lineArray[i].ToCharArray());
        for (int j = 0; j < charList[i].Length; j++)              
            digitList.Add(int.Parse(charList[i][j].ToString()));
    }

	// Product Solving
	long fourProduct = ParseProduct(digitList, 4);
	long thirteenProduct = ParseProduct(digitList, 13);

	// Output
	Console.WriteLine("The greatest product of four adjacent digits is: {0}", fourProduct);
	Console.WriteLine("The greatest product of thirteen adjacent digits is: {0}", thirteenProduct);
### ParseProduct
	static long ParseProduct(List<int> list, int counter)
        {
            long placeholder = 0;
            long product = 0;
            for (int i = 0; i < list.Count - counter; i++)
            {
                placeholder = list[i];
                for (int j = 1; j < counter; j++)
                    placeholder *= list[j+i];
                if (placeholder > product)
                    product = placeholder;
            }
            return product;
        }

## Implementation
Implementation went fine minus a few little hiccups here and there. My brackets got a bit messed up briefly, and I guess I wasn't converting the characters into integers correctly. But ultimately it was simply a few minor fixes before I was able to get it running without crashing. The console does however look for files in an odd place, so instead of just telling it to look for `1000Digits.txt` I have to tell it to look for `../../..1000Digits.txt`, which was a tad annoying.

## Testing
Once I got things properly running however, I realized that uh, it wasn't the right values! I didn't actually know what the thirteen-product number was supposed to be, but I knew what the four-product was, so that's why I included it. I figured if I could get the four-product correct, then the thirteen would be too since they're literally run by the same function.

My errors mostly came out to be how I was initalizing the character array, as I was doing that a bit wrong. I also found out that while I was incrementing that first value when I began the products, I would only ever multiply the first value by the 1st, 2nd, and 3rd values in the *entire* list. I wasn't incrementing it in a way to shift the whole product section forward as I moved through, so ultimately whatever the first product was was often the biggest product. That was my last issue, as four-product worked right after that.

Of course, not *fully* satisfied with just that working, I went out and tried to find the answer online to check my work. Thankfully, my theory was correct and `23514624000` is the correct answer! You love to see it.