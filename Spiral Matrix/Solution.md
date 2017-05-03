# Solution
This solution uses clockwise direction walking (`LEFT`, `DOWN`, `RIGHT`, `UP`) as the main way to solve this problem.
   * We start at the given `Point` location
   * I use a `for` loop to do the spiral walk clockwise direction step by step
   * Each step has 4 available moves in respected order `LEFT`, `DOWN`, `RIGHT`, `UP`. We will start with `LEFT`
   * As long as the next index location is not occupied or not out of bound, we will visit that index and switch the next direction for the new iteration.
   * If the index location is occupied, we would step in the backgward direction and begin check for empty index.
   * The loop stops when we run out of options to move (4 iterations).

Time complexity is `O(row * col)` because we have to traverse the whole matrix
Space compexity is `O(row * col)` because we only use the matrix 