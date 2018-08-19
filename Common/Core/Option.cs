using System;
using System.Collections.Generic;
using System.Linq;

namespace Core
{
    public abstract class Option<T> : IEquatable<Option<T>>, IEquatable<T>
    {
        public abstract void Do(Action<T> action);
        public abstract Option<TNew> Map<TNew>(Func<T, TNew> mapping);
        public abstract T Reduce(Func<T> whenNone);
        public abstract T Reduce(T whenNone);
        public abstract IEnumerable<T> AsEnumerable();
        public abstract Option<T> Where(Func<T, bool> predicate);

        public abstract bool Equals(Option<T> other);

        public abstract bool Equals(T other);

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Option<T>) obj);
        }

        public abstract override int GetHashCode();

        public static bool operator ==(Option<T> a, Option<T> b) =>
            (ReferenceEquals(null, a) && ReferenceEquals(null, b)) ||
            (!ReferenceEquals(null, a) && a.Equals(b));

        public static bool operator !=(Option<T> a, Option<T> b) => !(a == b);

        public static bool operator ==(Option<T> a, T b) =>
            !ReferenceEquals(null, a) && a.Equals(b);

        public static bool operator !=(Option<T> a, T b) => !(a == b);
    }

    public static class Option
    {
        public static Option<T> Some<T>(T value) => new SomeImpl<T>(value);
        public static Option<T> None<T>() => new NoneImpl<T>();

        private class SomeImpl<T> : Option<T>
        {
            private T Content { get; }

            public SomeImpl(T content)
            {
                this.Content = content;
            }

            public override void Do(Action<T> action) =>
                action(this.Content);

            public override Option<TNew> Map<TNew>(Func<T, TNew> mapping) =>
                new SomeImpl<TNew>(mapping(this.Content));

            public override T Reduce(Func<T> whenNone) =>
                this.Content;

            public override T Reduce(T whenNone) =>
                this.Content;

            public override IEnumerable<T> AsEnumerable() =>
                new[] { this.Content };

            public override Option<T> Where(Func<T, bool> predicate) =>
                predicate(this.Content) 
                    ? (Option<T>)(new SomeImpl<T>(this.Content)) 
                    : new NoneImpl<T>();

            public override bool Equals(Option<T> other) =>
                this.Equals(other as SomeImpl<T>);

            public override bool Equals(T other) =>
                this.ContentEquals(other);

            private bool Equals(SomeImpl<T> other) =>
                !ReferenceEquals(null, other) &&
                ContentEquals(other.Content);

            private bool ContentEquals(T other) =>
                (ReferenceEquals(null, this.Content) && ReferenceEquals(null, other)) ||
                (!ReferenceEquals(null, this.Content) && this.Content.Equals(other));

            public override int GetHashCode() =>
                this.Content?.GetHashCode() ?? 0;
        }

        private class NoneImpl<T> : Option<T>
        {
            public override void Do(Action<T> action) { }

            public override Option<TNew> Map<TNew>(Func<T, TNew> mapping) =>
                new NoneImpl<TNew>();

            public override T Reduce(Func<T> whenNone) =>
                whenNone();

            public override T Reduce(T whenNone) =>
                whenNone;

            public override IEnumerable<T> AsEnumerable() =>
                Enumerable.Empty<T>();

            public override Option<T> Where(Func<T, bool> predicate) =>
                this;

            public override bool Equals(Option<T> other) =>
                this.Equals(other as NoneImpl<T>);

            public override bool Equals(T other) => false;

            private bool Equals(NoneImpl<T> other) =>
                !ReferenceEquals(null, other);

            public override int GetHashCode() => 0;
        }
    }
}
