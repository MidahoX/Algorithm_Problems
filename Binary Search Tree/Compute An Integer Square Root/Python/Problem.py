"""
    Write a program which takes a non negative integer and returns the largest integer whose square 
    is less than or equal to the given integer. For example, if the input is 16, return 4; if the input
    is 300, return 17, since 17^2 = 289 < 300 and 18^2 = 324 > 300
"""

def square_root(n):
    # a brute force solution would be to iterate from 0 to N/2 and check the square of i to N.
    # we stop as soon as we exceed N -> O(N) time complexity
    # A better approach is to know the fact that if k^2 > N, we can skip [k, N]
    # if k^2 <= N then square of N could be k to N/2
    # let create start and end variable, let k = start + end / 2
    # if mid^2 > N -> end = mid - 1
    # if mid^2 <= N -> start = mid + 1
    # we will continue searching until start > end -> this is the first number where square exceed N
    # we would minus -1 to find the target number
    # Ex: 25 -> [0,25] -> [0,11] -> [6,5] -> target = 6 - 1=5
    start, end = 0, n
    # when mid^2 == N -> start would be equal to end -> start + 1 would cause the loop to terminate
    # then we - 1 from start + 1 to get start.
    while (start <= end):
        mid = (start + end) // 2
        if mid ** 2 > n:
            end = mid - 1
        else:
            start = mid + 1
    return start - 1  