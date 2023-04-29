import os
import subprocess
import sys
from slack_bolt import App
from slack_bolt.adapter.socket_mode import SocketModeHandler

app = App(token=os.environ.get("SLACK_BOT_TOKEN"))

@app.event("app_mention")
def image_generation(event,say):
	user_id = event["user"]
	command = event["text"]
	bot_id = os.environ.get("SLACK_BOT_ID")
	say(f"<@{user_id}> 少々お待ちください")
	command = command.replace(f"<@{bot_id}> ", "")
	my_env = os.environ.copy()
	try:
		process = subprocess.run(["python", "stable_diffusion.py", command, "--upload"], env=my_env, check=True)
		say(f"<@{user_id}> いかがでしょうか？")
	except:
		say(f"<@{user_id}> 指示方法を確認してください")


if __name__ == "__main__":
	SocketModeHandler(app, os.environ["SLACK_APP_TOKEN"]).start()
