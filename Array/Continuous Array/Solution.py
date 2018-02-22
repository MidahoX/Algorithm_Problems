class Solution:
    def findMaxLength(self, nums):
        """
        :type nums: List[int]
        :rtype: int
        """

        def isContinuousArray(nums):
            digitMap = [0, 0]
            for num in nums:
                digitMap[num] += 1
            return digitMap[0] == digitMap[1]

        maxLength = 0
        for frontIndex in nums:
            for rearIndex in nums[frontIndex + 1:]:
                subArray = nums[frontIndex: rearIndex + 1]
                if isContinuousArray(subArray) and maxLength < len(subArray):
                    maxLength = len(subArray)
        return maxLength

if __name__ == '__main__' :
    solution = Solution()
    print (solution.findMaxLength([0,1,0,1]))