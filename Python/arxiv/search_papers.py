import sys
import arxiv

# 検索するキーワードを引数から指定する
keyword = sys.argv[1]

# 論文を検索する
search = arxiv.Search(
	query = keyword,
	max_results = 10,
	sort_by = arxiv.SortCriterion.LastUpdatedDate,
	sort_order = arxiv.SortOrder.Descending
)

# 検索結果を表示する
for r in search.results():
	print(f'{r.title}: {r.pdf_url}')
