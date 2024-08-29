import os
import time
from selenium import webdriver
from bs4 import BeautifulSoup
from urllib.parse import urljoin

def get_svgs_from_website(url, output_folder):
    # Setup the Selenium WebDriver (using Chrome in this example)
    driver = webdriver.Chrome()

    # Load the website
    driver.get(url)

    # Wait for the page to fully load (adjust the sleep time if necessary)
    time.sleep(5)

    # Get the page source after JavaScript execution
    soup = BeautifulSoup(driver.page_source, 'html.parser')

    # Close the browser
    driver.quit()

    # Create the output folder if it doesn't exist
    if not os.path.exists(output_folder):
        os.makedirs(output_folder)

    # Find and save inline SVGs
    svgs = soup.find_all('svg')
    for i, svg in enumerate(svgs):
        svg_content = str(svg)
        file_path = os.path.join(output_folder, f'svg_inline_{i + 1}.svg')
        with open(file_path, 'w', encoding='utf-8') as f:
            f.write(svg_content)
        print(f'Inline SVG saved to {file_path}')
    
    # Find and download SVG files from <img> tags
    img_svgs = soup.find_all('img', {'src': lambda x: x and x.endswith('.svg')})
    for i, img in enumerate(img_svgs):
        svg_url = urljoin(url, img['src'])
        svg_name = f'svg_img_{i + 1}.svg'
        file_path = os.path.join(output_folder, svg_name)
        with open(file_path, 'wb') as f:
            f.write(requests.get(svg_url).content)
        print(f'SVG from <img> tag saved to {file_path}')
    
    # Find and download SVG files from <object> tags
    object_svgs = soup.find_all('object', {'data': lambda x: x and x.endswith('.svg')})
    for i, obj in enumerate(object_svgs):
        svg_url = urljoin(url, obj['data'])
        svg_name = f'svg_object_{i + 1}.svg'
        file_path = os.path.join(output_folder, svg_name)
        with open(file_path, 'wb') as f:
            f.write(requests.get(svg_url).content)
        print(f'SVG from <object> tag saved to {file_path}')
    
    # Find and download SVG files from <embed> tags
    embed_svgs = soup.find_all('embed', {'src': lambda x: x and x.endswith('.svg')})
    for i, embed in enumerate(embed_svgs):
        svg_url = urljoin(url, embed['src'])
        svg_name = f'svg_embed_{i + 1}.svg'
        file_path = os.path.join(output_folder, svg_name)
        with open(file_path, 'wb') as f:
            f.write(requests.get(svg_url).content)
        print(f'SVG from <embed> tag saved to {file_path}')
    
    # Find and download SVG files from CSS background-image
    style_svgs = soup.find_all(style=True)
    for i, element in enumerate(style_svgs):
        style_content = element['style']
        if '.svg' in style_content:
            start_index = style_content.find('url(') + 4
            end_index = style_content.find(')', start_index)
            svg_url = style_content[start_index:end_index].strip("'\"")
            svg_url = urljoin(url, svg_url)
            svg_name = f'svg_style_{i + 1}.svg'
            file_path = os.path.join(output_folder, svg_name)
            with open(file_path, 'wb') as f:
                f.write(requests.get(svg_url).content)
            print(f'SVG from style attribute saved to {file_path}')
    
    print('SVG extraction complete.')

# Usage example:
# "C:\Users\jacob\Desktop\hair.html"
url = 'file:///C:/Users/jacob/Desktop/hair.html'  # Replace with the target website URL
output_folder = 'svgs'  # Folder to save SVG files
get_svgs_from_website(url, output_folder)
