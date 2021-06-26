# FizzBuzz!

## Explanation
This is a first in a series of programming challenges to show how I program and demonstrate knowledge in specific skills or languages and the like.

FizzBuzz isn't a particularly difficult program. The goal is to print out numbers 1 to 100, but at certain intervals print out something *else*. For multiples of 3 I'll print 'Fizz', for multiples of 5 I'll print 'Buzz', and if it's a multiple of *both* I'll print...well, **both**! Nothing horribly impressive, but it does demonstrate some basic understandings. In addition, there is a goal of keeping this under 100 lines, but considering I could just print every single number by hand in 100 lines, I'm not exactly worried about that goal too much.

## Approach
FizzBuzz immediately looks like a `for` loop, and indeed that's correct. I'll have a big loop that does the counting, with a few small if statements that check the incrementation variable and, if it fits the criteria, prints out something else instead of just the normal number. This would likely use the modulus operator *(though I'm sure there's a way to do it without that)*, which I remember struggling a tiny bit with in the past but it shouldn't cause me too much difficulty.

## Pseudocode
	Run an incrementation variable one hundred times
		+If the number that variable equals is fully divisible by 3,
			-Output "Fizz", but don't end the line
		+If the number that variable equals is fully diviisble by 5,
			-Output "Buzz", but don't end the line
		+Otherwise,
			-Output the value of the incrementation variable, again with no endline
		+Add the endline in here.

## C# Code
	for (int i = 0; i < 100; i++){
		if (i % 3 == 0)
			Console.Write("Fizz");
		if (i % 5 == 0)
			Console.Write("Buzz");
		if (i % 3 != 0 && i % 5 != 0)
			Console.Write(i);
		Console.WriteLine();
	}

## Implementation 
Implementation went just fine! Mostly. I realize I forgot that it would count from 0 to 99 instead of 1 to 100, but that was a mostly easy fix. I would like to be able to run this from Bash's command line, but I suppose that's something I'll have to figure out later. Past that minor issue, it works great!

## Testing
Since this is a rather common challenge, I was able to look up what the solution was supposed to look like. I *could* copy that down and do a `git diff` on it, but that seems like a lot more work than just pulling up the correct output and my output and referring between the two. I didn't check every single number, but every random one I looked at matched and I checked about twenty of those, so I believe it should be working just fine. :)