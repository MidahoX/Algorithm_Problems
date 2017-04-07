Problem Statement

This is a design question. Pick an approach that works (there are several valid approaches), then describe classes, helper methods, and data structures that you would use to implement your approach. You should design with an eye towards: testability, readability, and maintainability.

Pseudocode is good. Actual code would be great.

Given a positive integer N, write an algorithm to populate an NxN int array. Place “1” in the center, and spiral clockwise out until you get to N^2. Assume that the starting coordinate (location of “1”) has been calculated for you:

public int[][] spiral (int n, Point start);

Examples:

N = 4

7 8 9 0
6 1 2 0
5 4 3 0
0 0 0 0


n = 5
21 22 23 24 25
20 7 8 9 10
19 6 1 2 11
18  5 4 3 12 
17 16 15 14 13


n = 4

7 8 9 10
6 1 2 11
5 4 3 12 
16 15 14 13

n = 3	

7 8 9
6 1 2
5 4 3

n = 2	

1 2
4 3

n = 1	

1