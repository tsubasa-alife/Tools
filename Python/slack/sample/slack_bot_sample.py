#slack boltによるBot作成のサンプル
import os
from slack_bolt import App
from slack_bolt.adapter.socket_mode import SocketModeHandler

#socket_modeでの起動
app = App(token=os.environ['SLACK_BOT_TOKEN'])

#ここにBotの行う処理を記述

if __name__ == '__main__':
    handler = SocketModeHandler(app,os.environ['SLACK_APP_TOKEN'])
    handler.start()
