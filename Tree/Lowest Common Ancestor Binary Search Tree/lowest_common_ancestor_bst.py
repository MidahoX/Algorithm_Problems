# Given values of two values n1 and n2 in a Binary Search Tree, find the Lowest Common Ancestor (LCA).
# You may assume that both the values exist in the tree.
#      20
#    /    \
#   8      22
#  / \
# 4   12
#    /  \
#   10  14

class Node:
    def __init__(self, key):
        self.key = key
        self.left = None
        self.right = None

# traverse the tree using BST property
# there are 3 cases
# case 1: n1 and n2 in the left substree -> n > n1 and n >n2 -> stop at n1 or n2 whichever larger
# case 2: n1 and n2 in two separate subtree -> n > n1 and n < n2 -> n would be the lca -> return
# case 3: n1 and n2 in the right subtree -> n < n1 and n <n2 -> stop at n1 or n2 whichever larger
# Time complexity is O(h) where h is the height of the tree for the worst case where the target nodes at the left
# Space complexity is O(h) for h recursive call stack for worst case
def find_lowest_common_ancestor(root :Node, n1:int, n2: int):
    if root is None:
        return None

    if root.key > n1 and root.key > n2:
        return find_lowest_common_ancestor(root.left, n1, n2)

    if root.key < n1 and root.key < n2:
        return find_lowest_common_ancestor(root.right, n1, n2)

    return root

def find_lowest_common_ancestor_iterative(root: Node, n1: int, n2: int):
    while(root is not None):
        if root.key > n1 and root.key > n2:
            root = root.left
        elif root.key < n1 and root.key < n2:
            root = root.right
        else:
            break
    return root

if __name__ == '__main__':
    node20 = Node(20)
    node8 = Node(8)
    node4 = Node(4)
    node22 = Node(22)
    node12 = Node(12)
    node10 = Node(10)
    node14 = Node(14)

    node20.left = node8
    node8.left = node4
    node8.right = node12
    node12.left = node10
    node12.right = node14
    node20.right = node22

    print(find_lowest_common_ancestor(node20, 4, 12).key)
    print(find_lowest_common_ancestor(node20, 10, 14).key)
    print(find_lowest_common_ancestor(node20, 14, 8).key)
    print(find_lowest_common_ancestor(node20, 10, 22).key)