namespace ReadAndFindInTree
{
	using System;
	using System.Collections.Generic;

	public class TreeNode<T>
	{
		private T value;
		private bool hasParent;
		private IList<TreeNode <T>> children;

		public TreeNode(T value)
		{
			this.Value = value;
			this.HasParent = false;
			this.children = new List<TreeNode <T>>();
		}

		

		public T Value {
			get
			{
				return this.value;
			}
			set
			{
				if(value == null)
				{
					throw new ArgumentNullException("Cannot insert null value!");
				}

				this.value = value;
			}
		}
		public bool HasParent { get; set; }

		public int ChildrenCount
		{
			get
			{
				return this.children.Count;
			}
		}

		public void AddChild(TreeNode<T> child)
		{
			if (child == null)
			{
				throw new ArgumentNullException("Cannot add null node!");
			}

			if (child.HasParent)
			{
				throw new ArgumentException("This node already has a parent!");
			}

			child.HasParent = true;
			this.children.Add(child);
		}

		public TreeNode<T> GetChild(int index)
		{
			return this.children[index];
		}
	}
}
