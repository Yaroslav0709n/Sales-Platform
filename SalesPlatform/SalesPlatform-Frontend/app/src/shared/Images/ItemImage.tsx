import React, { useState, useEffect } from 'react';
import axios from 'axios';
import styles from './ItemImage.module.css'

interface Image {
  id: number;
  imageData: string;
  caption: string;
};

interface ImageProps {
  itemId: string;
}

const ItemImage: React.FC<ImageProps> = ({ itemId }) => {
  const [photos, setPhotos] = useState<Image[]>([]);

  const token = localStorage.getItem('accessToken');
  const headers = {
    Authorization: `Bearer ${token}`,
  };

  useEffect(() => {
    axios.get(`https://localhost:44301/api/Photo?itemId=${itemId}`, {
      headers,
    })
      .then((response) => {
        setPhotos(response.data);
      })
      .catch((error) => {
        console.error('Error:', error);
      });
  }, [itemId]); 

  return (
    <div className={styles.image__container}>
    {photos.length > 0 && (
      <div>
        <img
          src={`data:image/jpeg;base64,${photos[0].imageData}`}
          alt={photos[0].caption}
          width={175}
          height={200}
        />
      </div>
    )}
  </div>
  );
}

export default ItemImage;
