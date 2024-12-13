#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using Microsoft.SemanticKernel;
using System.Threading.Tasks;
using syncfusion.demoscommon.wpf;

namespace syncfusion.diagramdemos.wpf.Views
{
    internal class SemanticKernelAI
    {

        string endpoint = "YOUR-AI-ENDPOINT";
        string deploymentName = "YOUR-DEPLOYMENT-NAME";
        internal string key = string.Empty;

        IChatCompletionService chatCompletionService;
        Kernel kernel;

        /// <summary>
        /// Initializes a new instance of the <see cref="SemanticKernelAI"/> class.
        /// </summary>
        /// <param name="key">Key for the semantic kernal API</param>
        public SemanticKernelAI(string apikey, string endPoint, string modelName)
        {
            this.key = apikey;
            this.endpoint = endPoint;
            this.deploymentName = modelName;
            var builder = Kernel.CreateBuilder().AddAzureOpenAIChatCompletion(deploymentName, endpoint, key);
            kernel = builder.Build();
            chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();
        }

        public async Task<string> GetResponseFromAI(string systemPrompt, AIDiagramLayout layoutType)
        {
            try
            {
                string completePrompt = BuildCompletePromptWithSystem(systemPrompt, layoutType);

                var history = new ChatHistory();
                history.AddSystemMessage(completePrompt);

                var openAIPromptExecutionSettings = new OpenAIPromptExecutionSettings
                {
                    ToolCallBehavior = ToolCallBehavior.AutoInvokeKernelFunctions
                };

                var result = await chatCompletionService.GetChatMessageContentAsync(
                    history,
                    executionSettings: openAIPromptExecutionSettings,
                    kernel: kernel);

                return result.ToString();
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Builds the complete prompt by integrating the system prompt with predefined guidelines for creating a Mermaid flowchart.
        /// </summary>
        /// <param name="systemPrompt">The title or description of the diagram process.</param>
        /// <returns>A fully formatted prompt string.</returns>
        private string BuildCompletePromptWithSystem(string systemPrompt, AIDiagramLayout layoutType)
        {
            string flowChartGuidelines = @"
You are an expert assistant specializing in generating precise Mermaid flowchart diagrams. For this task, generate a Mermaid flowchart for the process titled '{0}'.

Instructions:
- Title: The flowchart should represent the '{0}' process, with clear steps and decision points and keep the layout simple, avoiding complex layouts.
- Format: Use 'Yes' or 'No' branches for any conditional steps.
- Structure: Adapt each step and condition logically based on the '{0}' process.
- Colors: Use distinct colors to enhance visual appeal, with unique colors for each node type (e.g., start, process, decision, end). Ensure each node has contrasting, visually pleasing colors.

Example of the expected output structure:

graph TD
A([Start]) --> B[Choose Destination]
B --> C{{Already Registered?}}
C -->|No| D[Sign Up]
D --> E[Enter Details]
E --> F[Search Buses]
C --> |Yes| F
F --> G{{Buses Available?}}
G -->|Yes| H[Select Bus]
H --> I[Enter Passenger Details]
I --> J[Make Payment]
J --> K[Booking Confirmed]
G -->|No| L[Set Reminder]
K --> M([End])
L --> M
style A fill:#90EE90,stroke:#333,stroke-width:2px;
style B fill:#4682B4,stroke:#333,stroke-width:2px;
style C fill:#32CD32,stroke:#333,stroke-width:2px;
style D fill:#FFD700,stroke:#333,stroke-width:2px;
style E fill:#4682B4,stroke:#333,stroke-width:2px;
style F fill:#4682B4,stroke:#333,stroke-width:2px;
style G fill:#32CD32,stroke:#333,stroke-width:2px;
style H fill:#4682B4,stroke:#333,stroke-width:2px;
style I fill:#4682B4,stroke:#333,stroke-width:2px;
style J fill:#4682B4,stroke:#333,stroke-width:2px;
style K fill:#FF6347,stroke:#333,stroke-width:2px;
style L fill:#FFD700,stroke:#333,stroke-width:2px;
style M fill:#FF6347,stroke:#333,stroke-width:2px;

Please return only the formatted Mermaid flowchart code, following the example structure above, with no extra comments or symbols and always provide colors which is visible properly when foreground text is black.
";

            string mindMapGuideLines = @"
You are an assistant tasked with generating structured mind map diagram data sources in Mermaid syntax for the topic '{0}' based on user queries. The output should follow these guidelines:
1. The root parent should not have any tab space indentation.
2. Each sublevel should have tab indentation based on its depth.
3. Do not use any symbols like '+' or '-' before any level of data.
4. Do not add extra comments or explanations in the output.
5. Always start the structure with the word 'mindmap' as the root.

Example output:

mindmap
Learn Hacking
 Hacking Basics
  Ethical Hacking
   White Hat Hacking
   Black Hat Hacking
  Hacking Tools
   Metasploit
   Nmap
   Burp Suite
   Wireshark
 Hacking Techniques
  Phishing
  Social Engineering
  SQL Injection
  Cross-Site Scripting (XSS)
 Hacking Environments
  Linux for Hacking
  Virtual Machines
  Kali Linux
  BackBox
 Hacking Skills
  Programming Languages
   Python
   C/C++
   JavaScript
  Networking Basics
  Operating Systems
  Web Application Security

Note: Only return the structured Mermaid mind map syntax. No additional comments or symbols and follow for Capitalization for every word.
";

            switch (layoutType)
            {
                case AIDiagramLayout.FlowChart:
                    return string.Format(flowChartGuidelines, systemPrompt);

                case AIDiagramLayout.MindMap:
                    return string.Format(mindMapGuideLines, systemPrompt);

                default:
                    return string.Empty;
            }
        }

    }

    internal enum AIDiagramLayout
    {
        MindMap,
        FlowChart
    }
}
