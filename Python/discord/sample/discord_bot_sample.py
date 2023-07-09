import os
import discord


TOKEN = os.environ['DISCORD_BOT_TOKEN']


class BotClient(discord.Client):
	# 起動した時
	async def on_ready(self):
		print(f'Logged on as {self.user}!')

	# テキストチャンネルにメッセージが送信された時
	async def on_message(self, message):
		# Bot自身が送信したものには反応しない（再帰的呼び出しを避けるため）
		if message.author.bot:
			pass
		# Botに対してメンションされている時だけ反応する
		elif self.user in message.mentions:
			# メンションの情報をメッセージから除去するためsplitをしている
			text = message.content.split()[1]
			print(text)
			send_message = text
			# チャンネルに送信
			await message.channel.send(send_message)


if __name__== '__main__':
	intents = discord.Intents.default()
	intents.message_content = True
	# クライアントを生成
	client = BotClient(intents=intents)
	# クライアント起動
	client.run(TOKEN)