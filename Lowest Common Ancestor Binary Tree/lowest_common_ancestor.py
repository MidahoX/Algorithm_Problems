class Node:
    def __init__(self, key):
        self.key = key
        self.left = None
        self.right = None

# find the path to the first target, find the path to second target
# store those path as an array then traverse both array at the same time and stop when the value is different
# the previous value is the lowest common ancestor
# Time complexity: O(N)
# Worse case will need to search entire tree

def find_lowest_common_ancestor(root, target1, target2):
    target1_path = []
    target2_path = []
    find_path(root, target1_path, target1)
    find_path(root, target2_path, target2)
    if len(target1_path) == 0 or len(target1_path) == 0:
        return None

    target1_path.reverse()
    target2_path.reverse()

    i = 0
    while( i < len(target1_path) and i < len(target2_path)):
        if target1_path[i] != target2_path[i]:
            break
        i+=1
    return target1_path[i-1]

def find_path(root, path, value):
    if root is None:
        return False
    elif root.key == value:
        path.append(root.key)
        return True
    else:
        foundInLeft = find_path(root.left, path, value)
        if foundInLeft:
            path.append(root.key)
            return True

        foundInRight = find_path(root.right, path, value)
        if foundInRight:
            path.append(root.key)
            return True

if __name__ == '__main__':
    node1 = Node(1)
    node2 = Node(2)
    node3 = Node(3)
    node4 = Node(4)
    node5 = Node(5)
    node6 = Node(6)
    node7 = Node(7)
    node1.left = node2
    node1.right = node3
    node2.left = node4
    node2.right = node5
    node3.left = node6
    node3.right = node7
    lca = find_lowest_common_ancestor(node1, 2, 5)
    print(lca)