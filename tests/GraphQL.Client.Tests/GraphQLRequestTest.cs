using Xunit;

namespace GraphQL.Client.Tests {

	public class GraphQLRequestTest {

		[Fact]
		public void ConstructorFact() {
			var graphQLRequest = GraphQLRequest.New("{hero{name}}");
			Assert.NotNull(graphQLRequest.Query);
			Assert.Null(graphQLRequest.OperationName);
			Assert.Null(graphQLRequest.Variables);
		}

		[Fact]
		public void ConstructorExtendedFact() {
			var graphQLRequest = GraphQLRequest.New("{hero{name}}", new {varName = "varValue"}, "operationName");
			Assert.NotNull(graphQLRequest.Query);
			Assert.NotNull(graphQLRequest.OperationName);
			Assert.NotNull(graphQLRequest.Variables);
		}

		[Fact]
		public void Equality1Fact() {
			var graphQLRequest = GraphQLRequest.New("{hero{name}}");
			Assert.Equal(graphQLRequest, graphQLRequest);
		}

		[Fact]
		public void Equality2Fact() {
			var graphQLRequest1 = GraphQLRequest.New("{hero{name}}");
			var graphQLRequest2 = GraphQLRequest.New("{hero{name}}");
			Assert.Equal(graphQLRequest1, graphQLRequest2);
		}

		[Fact]
		public void Equality3Fact() {
			var graphQLRequest1 = GraphQLRequest.New("{hero{name}}", new { varName = "varValue" }, "operationName");
			var graphQLRequest2 = GraphQLRequest.New("{hero{name}}", new { varName = "varValue" }, "operationName");
			Assert.Equal(graphQLRequest1, graphQLRequest2);
		}

		[Fact]
		public void EqualityOperatorFact() {
			var graphQLRequest1 = GraphQLRequest.New("{hero{name}}", new { varName = "varValue" }, "operationName");
			var graphQLRequest2 = GraphQLRequest.New("{hero{name}}", new { varName = "varValue" }, "operationName");
			Assert.True(graphQLRequest1 == graphQLRequest2);
		}

		[Fact]
		public void InEquality1Fact() {
			var graphQLRequest1 = GraphQLRequest.New("{hero{name1}}");
			var graphQLRequest2 = GraphQLRequest.New("{hero{name2}}");
			Assert.NotEqual(graphQLRequest1, graphQLRequest2);
		}

		[Fact]
		public void InEquality2Fact() {
			GraphQLRequest graphQLRequest1 = GraphQLRequest.New("{hero{name}}", new { varName = "varValue1" }, "operationName");
			GraphQLRequest graphQLRequest2 = GraphQLRequest.New("{hero{name}}", new { varName = "varValue2" }, "operationName");
			Assert.NotEqual(graphQLRequest1, graphQLRequest2);
		}

		[Fact]
		public void InEqualityOperatorFact() {
			var graphQLRequest1 = GraphQLRequest.New("{hero{name1}}");
			var graphQLRequest2 = GraphQLRequest.New("{hero{name2}}");
			Assert.True(graphQLRequest1 != graphQLRequest2);
		}

		[Fact]
		public void GetHashCode1Fact() {
			var graphQLRequest1 = GraphQLRequest.New("{hero{name}}");
			var graphQLRequest2 = GraphQLRequest.New("{hero{name}}");
			Assert.True(graphQLRequest1.GetHashCode() == graphQLRequest2.GetHashCode());
		}

		[Fact]
		public void GetHashCode2Fact() {
			var graphQLRequest1 = GraphQLRequest.New("{hero{name}}", new { varName = "varValue" }, "operationName");
			var graphQLRequest2 = GraphQLRequest.New("{hero{name}}", new { varName = "varValue" }, "operationName");
			Assert.True(graphQLRequest1.GetHashCode() == graphQLRequest2.GetHashCode());
		}

		[Fact]
		public void GetHashCode3Fact() {
			var graphQLRequest1 = GraphQLRequest.New("{hero{name}}", new { varName = "varValue1" }, "operationName");
			var graphQLRequest2 = GraphQLRequest.New("{hero{name}}", new { varName = "varValue2" }, "operationName");
			Assert.True(graphQLRequest1.GetHashCode() != graphQLRequest2.GetHashCode());
		}

		[Fact]
		public void PropertyQueryGetFact() {
			var graphQLRequest = GraphQLRequest.New("{hero{name}}", new { varName = "varValue1" }, "operationName");
			Assert.Equal("{hero{name}}", graphQLRequest.Query);
		}

		[Fact]
		public void PropertyQuerySetFact() {
			var graphQLRequest = GraphQLRequest.New("{hero{name}}", new { varName = "varValue1" }, "operationName");
			graphQLRequest.Query = "{hero{name2}}";
			Assert.Equal("{hero{name2}}", graphQLRequest.Query);
		}

		[Fact]
		public void PropertyOperationNameGetFact() {
			var graphQLRequest = GraphQLRequest.New("{hero{name}}", new { varName = "varValue" }, "operationName");
			Assert.Equal("operationName", graphQLRequest.OperationName);
		}

		[Fact]
		public void PropertyOperationNameNullGetFact() {
			var graphQLRequest = GraphQLRequest.New("{hero{name}}");
			Assert.Null(graphQLRequest.OperationName);
		}

		[Fact]
		public void PropertyOperationNameSetFact() {
			var graphQLRequest = GraphQLRequest.New("{hero{name}}", new { varName = "varValue" }, "operationName1");
			graphQLRequest.OperationName = "operationName2";
			Assert.Equal("operationName2", graphQLRequest.OperationName);
		}

		[Fact]
		public void PropertyVariableGetFact() {
			var graphQLRequest = GraphQLRequest.New("{hero{name}}", new { varName = "varValue" }, "operationName");
			Assert.Equal(new { varName = "varValue" }, graphQLRequest.Variables);
		}

		[Fact]
		public void PropertyVariableNullGetFact() {
			var graphQLRequest = GraphQLRequest.New("{hero{name}}");
			Assert.Null(graphQLRequest.Variables);
		}

		[Fact]
		public void PropertyVariableSetFact() {
			var graphQLRequest = GraphQLRequest.New("{hero{name}}", new { varName = "varValue1" }, "operationName1");
			graphQLRequest.Variables = new {
				varName = "varValue2"
			};
			Assert.Equal(new {
				varName = "varValue2"
			}, graphQLRequest.Variables);
		}

	}

}
