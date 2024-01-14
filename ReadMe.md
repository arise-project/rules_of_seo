# Rules of SEO

Rules of SEO is a .NET tool designed to check whether a webpage adheres to specified rules. These rules define various aspects of the webpage content, such as titles, descriptions, and segments. The utility leverages a set of rules, keywords, and competitor information to validate the webpage content.

## Table of Contents

1. [Introduction](#introduction)
2. [Features](#features)
3. [Rules Configuration](#rules-configuration)
4. [Prerequisites](#prerequisites)
5. [Installation](#installation)
6. [Usage](#usage)
7. [Configuration Files](#configuration-files)
8. [Contributing](#contributing)
9. [License](#license)

## Introduction

This utility helps validate webpages against a set of predefined rules to ensure that the content meets specific criteria. It is particularly useful for maintaining consistency and quality across multiple webpages.

## Features

- **Rule-Based Validation:** The utility checks webpage content against a set of rules defined in the configuration.
- **Keyword Matching:** Rules include keyword matching for titles, descriptions, and segments.
- **Competitor Analysis:** Compares webpage content against competitor keywords and lengths.
- **Plagiarism Check:** Optional plagiarism check for specific content segments.

## Rules Configuration

The rules are defined in a configuration file (typically `rules.yaml`), and they cover various aspects of the webpage content. Some examples of rules include:

- Checking titles and descriptions against specified keywords.
- Enforcing minimum and maximum lengths for specific content segments.
- Allowing or disallowing the addition of paragraphs based on specific conditions.
- Performing competitor analysis, including checking lengths and uniqueness.

## Prerequisites

- **.NET SDK:** Ensure that you have the .NET SDK installed on your machine. If not, you can download it [here](https://dotnet.microsoft.com/download).

## Installation

1. **Clone the repository:**

    ```bash
    git clone https://github.com/yourusername/webpage-validation-utility-dotnet.git
    ```

2. **Navigate to the project directory:**

    ```bash
    cd webpage-validation-utility-dotnet
    ```

3. **Build the Solution:**

    ```bash
    dotnet build
    ```

## Usage

1. **Configure Rules:**

    Define your rules in the `rules.yaml` file.

2. **Prepare Keywords:**

    Create a `keywords.yaml` file containing the keywords relevant to your content.

3. **Run the Utility:**

    ```bash
    dotnet run --url http://yourwebsite.com
    ```

    Replace `http://yourwebsite.com` with the URL of the webpage you want to validate.

4. **Review Results:**

    The utility will provide feedback based on the defined rules.

## Configuration Files

- **rules.yaml:** Contains the rules for webpage validation.
- **keywords.yaml:** Specifies keywords relevant to the content.
- **competitor_keywords.yaml:** Keywords specific to competitor analysis.
- **competitors.yaml:** Information about competitors.

## Contributing

Contributions are welcome! If you have additional features, improvements, or bug fixes, feel free to open an issue or submit a pull request.

## License

This project is licensed under the [MIT License](LICENSE). See the LICENSE file for details.

Happy webpage validation!

TODO:
 
Pay attention: set location to united states or interesting region in keywordsd planner

#todo

1. setup all services in di
+2. IValidationUnit how to run?
+3. appSettings.json
	"SettingsFile": "./RuleSettings.yml",
    "DataFolder": "./Example/WordCounter/Data/",
    "TextFolder": "./Example/WordCounter/"	
4. yaml
	keywords-file: keywords.csv
	competitor-keywords-file: competitor_keywords.txt
	competitor-file: competitors.txt
5. actualize yaml rule-keys,  KeyToSlugResolver.cs
6. move unused logic
7. KeyToSlugResolver deep = 3
8. competiros competitor_keywords, keywords yaml
9. data folders structure by app
10. validator comments how it work
11. unnit test all walidator
12. remove ubused validators
13. add documnet
14. sync rule-keys in yaml
15. sync rules in yaml
16. low high parser in keywords.yaml
17. parse collection in competitors
18. Found all enpty chunks with slugs
18. List all not found slugs
