import openai
import os

# Set up your OpenAI API key
openai.api_key = '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'

# Define your prompt
prompt = "generate 10 song lines, from popular singers, the lines should be less than 10 words"

# Call the OpenAI API
response = openai.Completion.create(
  engine="gpt-3.5-turbo-instruct",
  prompt=prompt,
  temperature=0.5,
  max_tokens=50,
  n=10
)

file_path = os.path.join("Assets", "src", "Upal", "Code", "song_lines.txt")

# Extract and save the song lines to a text file
file = open(file_path, "w")
for idx, choice in enumerate(response.choices):
        line = choice.text.strip()
        if ('-' in line):
          print(line)
          file.write(line)
