# a max tree is built as
# the root is always the max of the array
# the left substre is the max tree construct from the left array
# the right subtree is the max tree construct from the right array
# Ex: 3 2 1 6 0 5
# 1st root  6, 3 2 1, 0 5
# 3, 2 1
# The brute force solution would be iterate through the array, get the max
# create a new TreeNode with that max value, then recursive build the left subtree on the left subarray, and same for right
# buildMaxTree(array, beginIndex, endIndex)
# 1 element -> TreeNode
# 2 element -> Treenode, left = buildMaxTree(leftsize)
# The time complexity: time complexity of one problem * the number of sub problem
# N * N -> N^2
import collections

class TreeNode:
    def __init__(self, x):
        self.x = x;
        self.left = None;
        self.right = None;

class Solution:
    def constructMaximumBinaryTree(self, nums):
        MaxValueWithIndex = collections.namedtuple('MaxValueWithIndex', ('value', 'index'))
        """
        :type nums: List[int]
        :rtype: TreeNode
        """
        if not nums:
            return None

        def constructMaxBST(nums, beginIndex, endIndex):
            if beginIndex > endIndex:
                return None
            if beginIndex == endIndex:
                return TreeNode(nums[beginIndex])

            maxValueWithIndex = findMax(nums, beginIndex, endIndex)
            root = TreeNode(maxValueWithIndex.value)
            root.left = constructMaxBST(nums, beginIndex, maxValueWithIndex.index - 1)
            root.right = constructMaxBST(nums, maxValueWithIndex.index + 1, endIndex)
            return root

        def findMax(nums, beginIndex, endIndex):
            maxValue = nums[beginIndex];
            maxIndex = beginIndex;
            for index in range(beginIndex, endIndex + 1):
                if maxValue < nums[index]:
                    maxValue = nums[index]
                    maxIndex = index
            return MaxValueWithIndex(maxValue, maxIndex)

        return constructMaxBST(nums, 0, len(nums) - 1)

if __name__ == "__main__":
    solution = Solution()
    root = solution.constructMaximumBinaryTree([3, 2, 1, 6 ,0 ,5])