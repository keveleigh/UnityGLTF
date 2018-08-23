using System.Runtime.Serialization;

namespace GLTF.Schema
{
	[DataContract]
	public class AccessorSparse : GLTFProperty
	{
		/// <summary>
		/// Number of entries stored in the sparse array.
		/// <minimum>1</minimum>
		/// </summary>
		[DataMember(Name = "count")]
		public int Count;

		/// <summary>
		/// Index array of size `count` that points to those accessor attributes that
		/// deviate from their initialization value. Indices must strictly increase.
		/// </summary>
		[DataMember(Name = "indices")]
		public AccessorSparseIndices Indices;

		/// <summary>
		/// "Array of size `count` times number of components, storing the displaced
		/// accessor attributes pointed by `indices`. Substituted values must have
		/// the same `componentType` and number of components as the base accessor.
		/// </summary>
		[DataMember(Name = "values")]
		public AccessorSparseValues Values;

		public AccessorSparse()
		{
		}
		
		public AccessorSparse(AccessorSparse accessorSparse, GLTFRoot gltfRoot) : base(accessorSparse)
		{
			if (accessorSparse == null) return;

			Count = accessorSparse.Count;
			Indices = new AccessorSparseIndices(accessorSparse.Indices, gltfRoot);
			Values = new AccessorSparseValues(accessorSparse.Values, gltfRoot);
		}
	}
}
