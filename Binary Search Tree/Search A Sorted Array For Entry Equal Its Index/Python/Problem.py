"""
    Search a sorted array of distinct element, and retrn an index such that the element at index i equals i. 
    For example, when input is <-2, 0, 2, 3, 6, 7, 9>, the algorithm should return 2 or 3
"""

def search_entry_equal_index(array):
    # since the array is sorted and distinct -> each element is at least 1 unit difference. 
    # we can start with the mid point of the array
    # if this mid point == mid point value -> return
    # otherwise, check if a[mid] - mid > 0 -> skip the right sub array (mid + 1, end)
    # otherwise skip the left sub array (start, mid - 1)
    # Time complexity O(logN) similar to Binary Search
    start, end = 0, len(array) - 1
    # the terminate condition include equal because there is no guaranteee the element existed.
    # we have to terminate when the difference is 0 instead of start == end
    while (start <= end):
        mid = (start + end) // 2
        difference = array[mid] - mid
        if difference == 0:
            return mid
        elif difference > 0:
            end = mid - 1
        else:
            start = mid + 1    
    return -1

if __name__ == '__main__':
    print(search_entry_equal_index([-2,0,2,3,6,7,9]))

        