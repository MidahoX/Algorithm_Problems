def IsPalindrome(input):
    # double slash -> divide get floor (integer)
    # ~ is the bitwise complement operator which is -x - 1
    # all() return True if all elements in the iterable return True
    return all(input[i] == input[~i] for i in range(len(input) // 2))

if __name__ == "__main__":
    inputs = ["", "a", "ab", "abc" , "aba", "abcd", "abcdedcba"]
    for i in range(len(inputs)):
        print (inputs[i] + " Palindrome: " + str(IsPalindrome(inputs[i])))