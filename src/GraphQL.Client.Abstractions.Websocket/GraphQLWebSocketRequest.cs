using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace GraphQL.Client.Abstractions.Websocket
{

    /// <summary>
    /// A Subscription Request
    /// </summary>
    public class GraphQLWebSocketRequest : Dictionary<string, object>, IEquatable<GraphQLWebSocketRequest>
    {
        public const string IdKey = "id";
        public const string TypeKey = "type";
        public const string PayloadKey = "payload";

        /// <summary>
        /// The Identifier of the Response
        /// </summary>
        public string Id
        {
            get => ContainsKey(IdKey) ? (string)this[IdKey] : null;
            set => this[IdKey] = value;
        }

        /// <summary>
        /// The Type of the Request
        /// </summary>
        public string Type
        {
            get => ContainsKey(TypeKey) ? (string)this[TypeKey] : null;
            set => this[TypeKey] = value;
        }

        /// <summary>
        /// The payload of the websocket request
        /// </summary>
        public GraphQLRequest Payload
        {
            get => ContainsKey(PayloadKey) ? (GraphQLRequest)this[PayloadKey] : null;
            set => this[PayloadKey] = value;
        }

        private TaskCompletionSource<bool> _tcs = new TaskCompletionSource<bool>();

        /// <summary>
        /// Task used to await the actual send operation and to convey potential exceptions
        /// </summary>
        /// <returns></returns>
        public Task SendTask() => _tcs.Task;

        /// <summary>
        /// gets called when the send operation for this request has completed sucessfully
        /// </summary>
        public void SendCompleted() => _tcs.SetResult(true);

        /// <summary>
        /// gets called when an exception occurs during the send operation
        /// </summary>
        /// <param name="e"></param>
        public void SendFailed(Exception e) => _tcs.SetException(e);

        /// <summary>
        /// gets called when the GraphQLHttpWebSocket has been disposed before the send operation for this request has started
        /// </summary>
        public void SendCanceled() => _tcs.SetCanceled();

        /// <inheritdoc />
        public override bool Equals(object obj) => this.Equals(obj as GraphQLWebSocketRequest);

        /// <inheritdoc />
        public bool Equals(GraphQLWebSocketRequest other)
        {
            if (other == null)
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            if (!Equals(this.Id, other.Id))
            {
                return false;
            }
            if (!Equals(this.Type, other.Type))
            {
                return false;
            }
            if (!Equals(this.Payload, other.Payload))
            {
                return false;
            }
            return true;
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            var hashCode = 9958074;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(this.Id);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(this.Type);
            hashCode = hashCode * -1521134295 + EqualityComparer<object>.Default.GetHashCode(this.Payload);
            return hashCode;
        }

        /// <inheritdoc />
        public static bool operator ==(GraphQLWebSocketRequest request1, GraphQLWebSocketRequest request2) => EqualityComparer<GraphQLWebSocketRequest>.Default.Equals(request1, request2);

        /// <inheritdoc />
        public static bool operator !=(GraphQLWebSocketRequest request1, GraphQLWebSocketRequest request2) => !(request1 == request2);

    }

}
