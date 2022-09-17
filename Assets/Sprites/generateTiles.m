tileSize = 64;
bandSize = 16;

img = zeros(tileSize, tileSize, 3, 'uint8');

img(:) = 255;
imwrite(img, 'center.png');

img(:) = 255;
img(1:bandSize, :, :) = 0;
imwrite(img, 'up.png');

img(:) = 255;
img(end-bandSize+1:end, :, :) = 0;
imwrite(img, 'bottom.png');

img(:) = 255;
img(:, 1:bandSize, :) = 0;
imwrite(img, 'left.png');

img(:) = 255;
img(:, end-bandSize+1:end, :) = 0;
imwrite(img, 'right.png');
