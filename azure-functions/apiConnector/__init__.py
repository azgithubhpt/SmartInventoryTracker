import logging
import requests

def main(req) -> float:
    api_key = "<your_api_key>"
    url = "https://api.apilayer.com/fixer/latest?base=USD&symbols=INR"
    headers = {"apikey": api_key}
    response = requests.get(url, headers=headers)
    if response.status_code == 200:
        rate = response.json()["rates"]["INR"]
        logging.info(f"USD to INR rate: {rate}")
        return rate
    else:
        logging.error("API call failed")
        return None
