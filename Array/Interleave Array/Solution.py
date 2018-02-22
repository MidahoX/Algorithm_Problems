from collections import deque
class Solution:
    def interleave_array(self, stack=[]):
        counter = 1
        queue = deque([])
        while counter < len(stack):
            while len(stack) > counter:
                number = stack.pop()
                queue.append(number)
            while len(queue) > 0:
                rear_number = queue.popleft()
                stack.append(rear_number)
            counter += 1
        return stack

if __name__ == "__main__":
    solution = Solution()
    result = solution.interleave_array([1, 2, 3, 4 ,5])
    while len(result) > 0:
        print(result.pop())
    result = solution.interleave_array([1, 2, 3, 4])
    while len(result) > 0:
        print(result.pop())
