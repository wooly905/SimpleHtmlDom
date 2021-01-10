# Simple Html Document Object Model
This is a simple HTML document object model that helps you generate HTML string programmatically.

Example 1 : Create an anchor element under a division element

```
            string id = "id1";
            string name = "name1";
            string style = "color:red";
            string href = "#";
            string text = "Website 1";

            Anchor anchor = new Anchor(id, name, href, text, AnchorTarget.Self, style);
            Division div = new Division();
            div.AddElement(anchor);

            Assert.Equal($"<div><a id=\"{id}\" name=\"{name}\" href=\"{href}\" style=\"{style}\">{text}</a></div>", div.ToHtml());
```

Element 2 : Create a header element under a paragraph element

```
            string text = "text";
            Header1 h1 = new Header1(text);
            Paragraph p = new Paragraph("This is a text ");
            p.AddElement(h1);
            Assert.Equal($"<p>This is a text <h1>{text}</h1></p>", p.ToHtml());
```

Element 3 : Create a table element based on a data model

```
            DateTime now = DateTime.Now;
            List<TestData2> data = new List<TestData2>();
            TestData2 element1 = new TestData2 { Id = 1, Name = "Name 1", CreatedTime = now };
            data.Add(element1);
            Table<TestData2> table = new Table<TestData2>(data);
            string actual = table.ToHtml();

            Assert.Equal($"<table width=\"100%\"><tr><th>First Name</th><th>Member Id</th><th>Created Time</th></tr><tr><td>Name 1</td><td>1</td><td>{now}</td></tr></table>", actual);

```

Example 4 : Create a table element based on a data model with customized data convertor

```
            List<TestData3> data = new List<TestData3>();
            TestData3 d3 = new TestData3(new List<string>() { "a", "b" });
            TestData3 d4 = new TestData3(new List<string>() { "c", "d" });
            data.Add(d3);
            data.Add(d4);

            Dictionary<string, Func<TestData3, string>> convertors = new Dictionary<string, Func<TestData3, string>>();
            convertors.Add(nameof(TestData3.Data), (x) => x.GetData());
            Table<TestData3> table = new Table<TestData3>(data, convertors);
            string actual = table.ToHtml();

            Assert.Equal("<table width=\"100%\"><tr><th>Test Data</th></tr><tr><td>a;b</td></tr><tr><td>c;d</td></tr></table>", actual);
```
