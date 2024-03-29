import argparse
import random
import os
import datetime
import requests
from io import BytesIO
from PIL import Image
from slack_sdk import WebClient
import torch
from diffusers import StableDiffusionImg2ImgPipeline

def main():
	parser = argparse.ArgumentParser(description="stable diffusionによるテキストからの画像生成")
	parser.add_argument("base",help="元画像")
	parser.add_argument("prompt",help="指示文")
	parser.add_argument("--seed",help="seed値")
	parser.add_argument("--h",help="画像縦サイズ",type=int,default=512)
	parser.add_argument("--w",help="画像横サイズ",type=int,default=512)
	parser.add_argument("--strength",help="変化の度合い",type=float,default=0.5)
	parser.add_argument("--waifu",help="日本のアニメ調にするかどうか",action="store_true")
	parser.add_argument("--upload",help="slackにアップロードするかどうか",action="store_true")

	args = parser.parse_args()

	date = datetime.datetime.now().strftime('%Y%m%d%H%M')

	device = "mps"
	seed = 1

	#引数でseedが指定されている場合はそれを利用する
	if(args.seed != None):
		seed = int(args.seed)
	else:
		seed = random.randint(1,10000)

	print(seed)

	torch.manual_seed(seed)

	model_id = "CompVis/stable-diffusion-v1-4"

	#日本のアニメ調の画像を生成する
	if(args.waifu):
		model_id = "hakurei/waifu-diffusion"


	prompt = args.prompt
	initial_image = Image.open(args.base).convert("RGB")
	initial_image = initial_image.resize((args.h,args.w))

	MY_TOKEN = os.environ["STABLE_DIFFUSION_TOKEN"]

	pipe = StableDiffusionImg2ImgPipeline.from_pretrained(model_id, use_auth_token=MY_TOKEN).to(device)

	image = pipe(prompt, initial_image, strength=args.strength)["sample"][0]

	filepath = f"results/{date}_img2img_seed_{seed}.jpeg"
	image.save(filepath)

	#slackへのアップロード
	if(args.upload):
		print("slackへアップロードします")
		client = WebClient(os.environ["SLACK_BOT_TOKEN"])
		auth_test = client.auth_test()

		upload_file = client.files_upload(
			channels="#stable-diffusion",
			file=filepath,
			initial_comment="Images generated by stable-diffusion"
		)


if __name__ == "__main__":
	main()