# 📘 What is MarkdownViewer?

MarkdownViewer is a UI component that displays **Markdown (.md) content** inside an application.
It converts Markdown syntax into formatted text, headings, tables, code blocks, diagrams, and more.

MarkdownViewer is commonly used in:
- Documentation panels  
- Help/Info screens  
- Developer tools  
- In‑app editors  
- Sample or demo UI screens  

It provides a clean and readable way to show technical or formatted content without HTML.

---

# MarkdownViewer – Advanced Features Demo

This sample shows advanced formatting features often supported in enhanced MarkdownViewer controls.

---

## 1) Superscript

Superscript is commonly used for math, chemistry, and footnotes.

Example:

- E = mc<sup>2</sup> 
- X<sup>10</sup> + Y<sup>2</sup>  
- Trademark™ can be written as TM<sup>®</sup>

## 2) Subscript

Subscript is used in scientific formulas, chemical expressions, and indexing.

Examples:

- H<sub>2</sub>O (Water)  
- CO<sub>2</sub> (Carbon dioxide)  
- Variable a<sub>2</sub>, a<sub>2</sub>, a<sub>3</sub> for indexing
                        
---

## 3) Blockquotes

Blockquotes visually highlight notes, messages, or documentation hints.

###### Example:
> This is a standard blockquote.  
> Useful for warnings, info notes, and documentation messages.

###### Nested blockquote:
> This is level1 blockquote.  
>> This is level2 blockquote.
>>> This is level3 blockquote.

---

## 4) Code Blocks (Fenced)

Code blocks are used for samples, configuration, and developer snippets.

Example (C++):

```
#include <iostream>
#include <string>

int main() {
    std::string user = "MarkdownViewer";
    std::cout << "Hello from " << user << "! Rendering works perfectly." << std::endl;

    // Demonstrate a small loop
    for (int i = 1; i <= 3; ++i) {
        std::cout << "Test run #" << i << " OK" << std::endl;
    }

    return 0;
}
```
<br>

### ✔ Mermaid Diagrams
Allows embedding diagrams such as flowcharts, sequence diagrams, and org charts.

---

# 🐬 What is Mermaid?

**Mermaid** is a text‑based diagramming language that allows you to create charts and diagrams directly inside Markdown.

It is widely used for:
- Flowcharts  
- Sequence diagrams  
- Gantt charts  
- Class diagrams  
- State diagrams  
- Pie charts  
- Entity‑relationship diagrams  

You define diagrams using simple text, and the renderer draws them.

# 🔁 Mermaid Flowchart Example

Below is a Mermaid flowchart you can use to test your MarkdownViewer:

```mermaid
flowchart TD
    A[User Opens App] --> B[MarkdownViewer Loads]
    B --> C{Contains Mermaid?}
    C -->|Yes| D[Render Diagram]
    C -->|No| E[Render Plain Markdown]
    D --> F[Display Enhanced Output]
    E --> F