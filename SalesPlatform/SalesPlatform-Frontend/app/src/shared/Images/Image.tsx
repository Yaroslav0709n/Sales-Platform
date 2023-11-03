import React, { useState, useEffect } from 'react';
import axios from 'axios';

interface Image{
  id: number;
  imageData: string; 
  caption: string;
};

interface ImageProps{
  itemId: string;
} 

const PhotoGallery: React.FC<ImageProps> = ({itemId}) => {
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
  }, []);
  

  return (
    <div>
      <div className="photo-container">
        {photos?.map((photo) => (
          <div key={photo.id}>
            <img
              src={`data:image/jpeg;base64,${photo.imageData}`}
              alt={photo.caption}
              width={100}
            />
            <p>{photo.caption}</p>
          </div>
        ))}
      </div>
    </div>
  );
}

export default PhotoGallery;
