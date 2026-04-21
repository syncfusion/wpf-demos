#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Threading.Tasks;
using Azure.AI.OpenAI;
using Microsoft.Extensions.AI;
using syncfusion.demoscommon.wpf;

namespace syncfusion.diagramdemos.wpf.Views
{
    internal class SemanticKernelAI
    {
        private static IChatClient clientAI;

        /// <summary>
        /// Initializes a new instance of the <see cref="SemanticKernelAI"/> class.
        /// </summary>
        /// <param name="key">Key for the semantic kernal API</param>
        public SemanticKernelAI(string apikey, string endPoint, string modelName)
        {
            clientAI = new AzureOpenAIClient(new System.Uri(endPoint), new System.ClientModel.ApiKeyCredential(apikey)).GetChatClient(modelName).AsIChatClient();
        }

        public async Task<string> GetResponseFromAI(string systemPrompt, AIDiagramLayout layoutType)
        {
            try
            {
                string completePrompt = BuildCompletePromptWithSystem(systemPrompt, layoutType);

                if (AISettings.ClientAI != null)
                {
                    //// Send the chat completion request to the OpenAI API and await the response.
                    var response = await AISettings.ClientAI.GetResponseAsync(completePrompt);
                    return response.ToString();
                }
            }
            catch
            {
                return string.Empty;
            }
            return string.Empty;
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

            string sequenceDiagramGuideLines = @"
You are an assistant tasked with generating structured sequence diagram Mermaid data for the scenario '{0}' based on the guidelines below. The output should strictly adhere to these rules and must not include any markdown code fences or the string '```mermaid' at the beginning.

1. Begin the diagram with the keyword 'sequenceDiagram' as the root.
2. List all necessary participants using 'actor' or 'participant' as appropriate and for all user type participant use 'actor'.
3. Use only these message arrows to denote interactions: (->>, -->>, <<->>, -) or --)). Specifically:
    - Use ->> for Sync, Delete, and Self messages.
    - Use -) for Async and Create messages.
    - Use --) for Reply messages.
4. For self messages (a participant communicating with itself), use the appropriate arrow syntax (->>).
5. Always include activation and deactivation markers to denote active periods for interactions.
6. Always include at least one fragment block (using 'alt', 'loop', or 'opt') even if the scenario does not inherently suggest conditional or repeated interactions.
7. Include at least one create/destroy message pair to illustrate the lifecycle of participants, even if not strictly implied by the scenario.
8. Ensure the diagram has a minimum of 10 interaction steps to represent an intermediate to high level of complexity.
9. After a create command (e.g., 'create participant X'), ensure that the subsequent message logically follows the creation event, originating from the participant responsible for the creation and directed to the newly created participant.
10. Ensure that indentation and formatting reflect the logical hierarchy and flow of interactions.
11. Do not include any extra comments, explanations, or symbols beyond the required Mermaid syntax.
12. The output must be creative and varied each time while strictly following these guidelines.
13. Give complex diagrams only

Basic simple examples for your context, but you try to create a complex diagram with all the given elements:

Example 1: All Types of Messages
sequenceDiagram
actor Client
participant Server
Client ->> Server: Sync Request
Server -) Client: Async Notification
Client -->> Server: Reply Message
Client ->> Client: Self Check
Server ->> Client: Delete Record

Example 2: With Activations
sequenceDiagram
participant User
participant Service
User ->> Service: Start Process
activate Service
Service -->> User: Process Acknowledged
deactivate Service

Example 3: With Fragments
sequenceDiagram
participant User
participant System
alt Successful Login
    User ->> System: Enter Credentials
    activate System
    System -->> User: Login Successful
    deactivate System
else Failed Login
    loop Retry up to 3 times
        User ->> System: Re-enter Credentials
    end
end

Example 4: With Create/Destroy Messages
sequenceDiagram
actor Admin
create participant Worker as DataProcessor
Admin -) Worker: Initialize Service
activate Worker
Worker ->> Admin: Service Ready
deactivate Worker
destroy Worker

Return only the structured Mermaid sequence diagram syntax.
";


            switch (layoutType)
            {
                case AIDiagramLayout.FlowChart:
                    return string.Format(flowChartGuidelines, systemPrompt);

                case AIDiagramLayout.MindMap:
                    return string.Format(mindMapGuideLines, systemPrompt);

                case AIDiagramLayout.SequenceDiagram:
                    return string.Format(sequenceDiagramGuideLines, systemPrompt);

                default:
                    return string.Empty;
            }
        }

    }

    internal enum AIDiagramLayout
    {
        MindMap,
        FlowChart,
        SequenceDiagram
    }
}
