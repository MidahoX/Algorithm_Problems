""" Search a key in binary search tree
"""
from bst import figure14_1
from bst import BSTNode

def search_bst(tree: BSTNode, key):
    if tree is None:
        print('None')
        return tree

    print(tree.data)
    if tree.data == key:
        return tree
    elif tree.data > key:
        return search_bst(tree.left, key)
    elif tree.data <= key:
        return search_bst(tree.right, key)

if __name__ == "__main__":
    root = figure14_1()
    search_bst(root, 13)
