import React, { useEffect, useState } from 'react';
import axios, { AxiosRequestConfig } from 'axios';
import {
  Div,
  Item,
  ItemList,
  DivState
} from './ItemsList.elements';


interface ItemDto {
    $id: string,
    id: string,
    name: string;
    description: string;
    price: number;
    time: string;
    city: string,
    state: string
  }


const ItemsList: React.FC = () => {
  const [items, setItems] = useState<ItemDto[]>([]);
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
    <Div>
      <h2>Advertisements</h2>
      <ItemList>
        {items?.map((item) => (
          <Item key={item.id}>
            <p>{item.name}</p>
            <DivState >
              <p>{item.state}</p>
            </DivState>
            <p>{item.city} - {item.time.split("T")[0]}</p>
          </Item>
        ))}
      </ItemList>
    </Div>
  );
};

export default ItemsList;