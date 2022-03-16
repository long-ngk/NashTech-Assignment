import Resizer from 'react-image-file-resizer';

export const resizeFileToBlob = async (file, setStateCallback) => {
    Resizer.imageFileResizer(
        file,
        250,
        250,
        'JPEG',
        100,
        0,
        (uri) => {
            console.log(uri);
            setStateCallback(uri);
          },
        'blob',
        200,
        200,
    );
};

export const resizeFileToBase64 = async (file, setStateCallback) => {
    Resizer.imageFileResizer(
        file,
        250,
        250,
        'JPEG',
        100,
        0,
        uri => {
            console.log(uri);
            setStateCallback(uri);
        },
        'base64',
        200,
        200,
    );
};