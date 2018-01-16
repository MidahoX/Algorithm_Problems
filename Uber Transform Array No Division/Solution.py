"""The solution contains a method that transform an array [i] = a[0->i-1] * a[i+1 -> n-1]"""

class Solution:
    """Solution"""
    def transform_array(self, numbers):
        n = len(numbers)
        #front product at i = a[0->i]
        front_products = [None] * n
        #back product at i = a[n-1 -> i]
        back_products = [None] * n
        new_numbers = [None] * n
        for i in range(n):
            if i == 0:
                front_products[i] = numbers[i]
                back_products[n-1-i] = numbers[n-1-i]
            else:
                front_products[i] = front_products[i-1] * numbers[i]
                back_products[n-1-i] = back_products[n-1-i+1] * numbers[n-1-i]
        for i in range(n):
            if i == 0:
                new_numbers[i] = back_products[i+1]
            elif i == n - 1:
                new_numbers[i] = front_products[i-1]
            else:
                new_numbers[i] = front_products[i-1] * back_products[i+1]
        return new_numbers

if __name__ == "__main__":
    solution = Solution()
    result = solution.transform_array([1, 2, 3, 4, 5, 6])
    #result = [720,360,240,180,144,120]
    print(result)
    result = solution.transform_array([0,0,0,0])
    #result = [0,0,0,0]
    print(result)
    