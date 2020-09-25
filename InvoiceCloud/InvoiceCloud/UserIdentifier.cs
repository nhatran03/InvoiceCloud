using InvoiceCloud.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCloud
{
	public class UserIdentifier : IUserIdentifier
	{
		public long UserId { get; protected set; }

		protected UserIdentifier()
		{

		}

		public UserIdentifier(long userId)
		{
			UserId = userId;
		}

		public static UserIdentifier Parse(string userIdentifierString)
		{
			if (userIdentifierString.IsNullOrEmpty())
			{
				throw new ArgumentNullException(nameof(userIdentifierString), "user can not be null or emoty!");
			}

			var splitted = userIdentifierString.Split('@');
			if(splitted.Length == 1)
			{
				return new UserIdentifier(splitted[0].To<long>());
			}

			throw new ArgumentException("user is not properly formatted", nameof(userIdentifierString));
		}

		public override bool Equals(object obj)
		{
			if(obj == null || !(obj is UserIdentifier))
			{
				return false;
			}

			if (ReferenceEquals(this, obj))
			{
				return true;
			}

			var other = (UserIdentifier)obj;
			var typeOfThis = GetType();
			var typeOfOther = other.GetType();

			if(!typeOfThis.IsAssignableFrom(typeOfOther) && !typeOfOther.IsAssignableFrom(typeOfThis))
			{
				return false;
			}

			return UserId == other.UserId;
		}

		public override int GetHashCode()
		{
			return (int)UserId;
		}

		public static bool operator ==(UserIdentifier left, UserIdentifier right)
		{
			if(Equals(left, null))
			{
				return Equals(right, null);
			}
			return left.Equals(right);
		}

		public static bool operator !=(UserIdentifier left, UserIdentifier right)
		{
			return !(left == right);
		}

		public override string ToString()
		{
			return String.Format("UserId {0}", UserId);
		}
	}
}
