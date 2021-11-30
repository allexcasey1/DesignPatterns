using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns
{
    public class ClassElement
    {
        public string Name;
        public List<ClassProperty> Children = new List<ClassProperty>();
        const int IndentSize = 2;

        public ClassElement() { }
        public ClassElement(string name)
        {
            Name = name;
        }
        private string ToStringImpl(int indent)
        {
            var sb = new StringBuilder();
            var i = new string(' ', IndentSize * indent);
            sb.Append($"{i}public class {Name}\n{{\n");
            foreach (var child in Children)
            {
                sb.Append(child.ToStringImpl(indent + 1));
            }
            sb.Append("}");

            return sb.ToString();
        }
        public override string ToString()
        {
            return ToStringImpl(0);
        }
    }
    public class ClassProperty
    {
        public string Type, Name;
        private const int IndentSize = 2;

        public ClassProperty() { }
        public ClassProperty(string type, string name)
        {
            Type = type;
            Name = name;
        }

        public string ToStringImpl(int indent)
        {
            var sb = new StringBuilder();
            var i = new string(' ', IndentSize * indent);
            sb.Append($"{i}public {Name} {Type};\n");
            return sb.ToString();
        }

        public override string ToString()
        {
            return ToStringImpl(0);
        }
    }
    public class CodeBuilder
    {
        private readonly string rootName;

        public CodeBuilder(string rootName)
        {
            this.rootName = rootName;
            root.Name = rootName;
        }
        public CodeBuilder AddField(string childName, string childType)
        {
            var e = new ClassProperty(childName, childType);
            root.Children.Add(e);
            return this;
        }

        public override string ToString()
        {
            return root.ToString();
        }

        public void Clear()
        {
            root = new ClassElement { Name = rootName };
        }

        ClassElement root = new ClassElement();
    }

}
