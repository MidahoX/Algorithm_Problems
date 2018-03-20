# binary search tree is a binary tree where each node value is greater than the left subtree node and less than or equal to the right subtree node.
class BSTNode:
    def __init__(self, data=None, left=None, right=None):
        self.data, self.left, self.right = data, left, right

def figure14_1():
    node19 = BSTNode(19)
    node7 = BSTNode(7)
    node3 = BSTNode(3)
    node2 = BSTNode(2)
    node5 = BSTNode(5)
    node13 = BSTNode(13)
    node17 = BSTNode(17)
    node11 = BSTNode(11)
    node43 = BSTNode(43)
    node23 = BSTNode(23)
    node37 = BSTNode(37)
    node29 = BSTNode(29)
    node31 = BSTNode(31)
    node41 = BSTNode(41)
    node47 = BSTNode(47)
    node53 = BSTNode(53)
    node19.left = node7
    node7.left = node3
    node3.left = node2
    node3.right = node5
    node11.right = node17
    node7.right = node11
    node17.left = node13
    node19.right = node43
    node43.left = node23
    node23.right = node37
    node37.left = node29
    node37.right = node41
    node43.right = node47
    node47.right = node53
    return node19
