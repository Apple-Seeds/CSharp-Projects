# FirstNonRepeatingCharacter

## Explanation
This is a decently simple progra that takes a string as input, and returns the first letter in that string that doesn't repeat. So given something like 'aaabcccdeeef', the answer would be 'b', since that's the first character in the string that's entirely on its own. Pretty simple program, but the approach will likely just be a tad more confusing.

## Approach
My idea on how to go about solving this problem is to use a dictionary. Strings are just big character arrays, so I can take in a string and split it into a dictionary with every unique character inside of it serving as the key. From there, I can make the value for each key the number of instances that character shows up in the string. What this should ultimately end up with is a dictionary with every unique character in order, with a corresponding amount of values for each key. 

Since the letters would be in order, whichever key is the first one to have only 1 point, then that's our first non-repeater, and I can return that using some small function. I considered just using a char array, but I realize that there may be instances like 'abcabcabc', where there is *no* repeating characters at all. In which case I'm going to return some absurd value that could never be an answer, and use that as an indication if there's no repeats. The best way to ensure that trigger will never be a possible answer is to make it longer than a single character, which means the function is going to return a string instead. That way I can still return a single character for valid strings, and some dummy answer in case it's invalid.

## Pseudocode
### Main
	// Input
    Ask the user to give a string
    Get the input and put it into a string

    // Processing
    Create a dictionary to insert values into
    For every character in the string,
        +If the selected character isn't in the dictionary,
            -Add that character into the dictionary as a key with a value of 1, for how many times it's shown up thus far.
        +Otherwise it's already in the dictionary, in which case...
            -Add one to the value for the corresponding key.

    // Output
    Do the calculation to figure out the first non-repeating number, and put that value into a string
    If that string is our dummy answer,
        +Alert the user that there's no non-repeating character
    Otherwise,
        +Output the string and inform the user that it's the first non-repeat

### Output
	For each element in the dictionary,
        +If it's value is 1,
            Return that key as a string
    Return a dummy answer if there doesn't end up being any key with a value of 1.

## C# Code
### Main
	// Input
    Console.Write("Enter a string: ");
    string entry = Console.ReadLine().ToLower();

    // Processing
    Dictionary<char, int> letters = new Dictionary<char, int>();
    for (int i = 0; i < entry.Length; i++)
    {
        if (!letters.ContainsKey(entry[i]))
            letters.Add(entry[i], 1);
        else
            letters[entry[i]]++;
    }

    // Output
    string answer = Output(letters);
    if (answer.Equals("404"))
        Console.WriteLine("There is no non-repeating character.");
    else
        Console.WriteLine("The first non-repeating character is: '" + answer + "'");

### Output
	foreach (KeyValuePair<char, int> element in let)
        if (element.Value == 1)
            return element.Key.ToString();
    return "404";

## Implementation 
Implementation took a little while, as I will be honest I forgot that dictionaries existed and attempted to use a list for a little while. While trying to figure out how to convert a list into a 2D so I could have the first row be the characters and the second row be the amount of times each one showed up, I remembered that idea sounded a lot like a dictionary, and thus adjusted things from there. I will also admit that for the `Output()` function I did end up looking at the documentation for dictionaries. I wasn't sure how to access the values and keys to get which key was the first one with a value of 1, so the `foreach` inside that function I did have to take from the documentation. Thankfully, that was really the only thing I had to look up! Everything else worked pretty well!

## Testing
The place I got this challenge from had a bunch of various inputs I could use to test, so I threw those in once I was done to ensure it came out with the same answer every time. Thankfully, after multiple runs, nothing was out of place! I was a little worried since I know dictionaries in python don't have a set order, and that was a *heavily* important part of getting this program to work, but thankfully this all worked out just fine. 