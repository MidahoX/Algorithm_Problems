"""
    Find the first occurrence of k in a sorted array
"""

# We can use binary search to find index of k then traverse back
# binary search:
#   get mid = length / 2
#   if mid == target -> return mid
#   if mid > target -> return (start, mid - 1)
#   else return (mid, end)


def bst(array, target, start, end):
    if start > end:
        return -1
    mid = (start + end) // 2
    if array[mid] == target:
        return mid
    elif array[mid] > target:
        return bst(array, target, start, mid - 1)
    else:
        return bst(array, target, mid + 1, end)

# find the index of k using BST -> O(logN)
# backtracking until meet non equal k element, return that index + 1
# O(logN + logN) = O(logN)


def find_first_occurence_k_naive(array, k):
    k_index = bst(array, k, 0, len(array) - 1)
    for i in range(k_index, 0, -1):
        if array[i] != k:
            return i+1

# instead of backtracking, use iteration to implement bst
# the basic idea of BST is that we have a set of candidate solutions
# each time we split the array into half. If we found the index at mid == target,
# we know we can discard the right half.
def find_first_occurrence_k_iter(array, k):
    left, right, result = 0, len(array) - 1, -1
    while(left <= right):
        mid = (left+right)//2
        if array[mid] == k:
            result = mid
            right = mid - 1
        elif array[mid] > k:
            right = mid - 1
        else:
            left = mid + 1
    return result

if __name__ == "__main__":
    array = [-14, -10, 108, 108, 243, 285, 285, 285, 401]
    # bst test
    #print (bst(array, -14, 0, len(array) - 1))
    print(find_first_occurence_k_naive(array, 108))
    print(find_first_occurrence_k_iter(array, 108))
