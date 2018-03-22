"""
    An array is said to be cyclically sorted if it is possible to cyclically shift its entries 
    so that it becomes sorted.
    Ex: [378, 478,550,631,103,203,220,234,279,368]
    if shift by 4, it becomes sorted array

    Design an O(logN) algorithm for finding the smallest element in the cyclically array
"""

def search_smallest(A):
    # Note: if an array is sorted, first element would be smallest then last element
    # We can utilize binary search concept, we pick the mid point element, compare it with the last element
    # if mid point is smaller than end -> we are on the right side of the smallest element -> search from start to mid
    # if mid point is larger than end -> we are at the left side of the smallest element -> search midpoint + 1 to end
    # this would stop when start == end -> smallest element
    # each time we divide the array in half and repeat the process on the part that would contain the smallest element
    start, end = 0, len(A)
    # ending condition is start < end no equal because we know the smallest element exist given the fact that is a acyclically sorted.
    while(start < end):
        mid = (start + end) // 2
        if A[mid] < A[end]:
            end = mid
        elif A[mid] > A[end]:
            start = mid + 1
    return A[start]