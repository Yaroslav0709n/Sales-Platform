import React, { useEffect, useState } from 'react';
import axios, { AxiosRequestConfig } from 'axios';
import styles from './ItemsList.module.css'
import {Item} from '../../../interfaces/Item/Item'
import ItemCard from '../../../shared/Cards/ItemCard'

const ItemsList: React.FC = () => {
  const [items, setItems] = useState<Item[]>([]);
  const [pageNumber, setPageNumber] = useState(2);
  const [count, setCount] = useState(10); 

  const token = localStorage.getItem('accessToken');
  const headers: AxiosRequestConfig['headers'] = {
    Authorization: `Bearer ${token}`, 
  };


  useEffect(() => {      
      axios.get(`https://localhost:44301/api/ItemСontroller?PageNumber=${pageNumber}&Count=${count}`, {
        headers
      })
      .then(response => {
          setItems(response.data);
      })
      .catch(error => {
          console.error('Error: ', error);
      });
  }, []);

  return ( 
    <div>
        {items?.map((item) => (
          <ItemCard 
            key={item.id}
            item={item}
          />
        ))} 
    </div>
  );
};

export default ItemsList;