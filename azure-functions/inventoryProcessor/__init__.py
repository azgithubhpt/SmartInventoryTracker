import logging
import json

def main(blob: bytes) -> None:
    inventory = json.loads(blob)
    for item in inventory:
        logging.info(f"Item: {item['item_id']} - {item['name']} - Qty: {item['quantity']}")
