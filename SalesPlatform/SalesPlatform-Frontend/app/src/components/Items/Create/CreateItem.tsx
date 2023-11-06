import React, { useEffect, useState } from 'react';
import axios, { AxiosRequestConfig } from 'axios';
import { useNavigate } from 'react-router-dom';
import styles from './CreateItem.module.css'
import EnterInput from '../../../shared/Inputs/EnterInput/EnterInput';
import { ItemDto } from '../../../interfaces/Item/Item';
import { ItemCategory } from '../../../interfaces/ItemCategory/ItemCategory';

const ItemsList: React.FC = () => {
  const navigate = useNavigate(); 
  const [newItem, setNewItem] = useState<ItemDto>({
    name: '',
    description: '',
    price: 0,
    city: '',
    state: '',
  });
  const [categories, setCategories] = useState<ItemCategory[]>([]);
  const [category, setCategory] = useState('');

  const token = localStorage.getItem('accessToken');
  const headers: AxiosRequestConfig['headers'] = {
    Authorization: `Bearer ${token}`, 
  };

  const handleCreateItem = async () => {
    try {
      const response = await axios.post(
        `https://localhost:44301/api/ItemСontroller/categoryId?categoryId=3`,
        newItem,
        {
          headers,
        }
      );
      console.log(response.data);
      navigate('/items');
    } catch (error) {
      console.error('Error: ', error);
    }
  };

  useEffect(() => {
        axios.get(`https://localhost:44301/api/ItemCategory`, {
            headers
        })
        .then(response => {
            console.log(response.data)
            setCategories(response.data);
        })
        .catch(error => {
            console.error('Error: ', error);
        });
  }, [])

  const handleCategoryChange = (event:any) => {
    setCategory(event.target.value); 
  }

  return ( 
    <div>
        <div className={styles["create__item-name"]}>
            <label>Enter a name</label>
            <EnterInput 
                type="text"
                value={newItem.name} 
                onChange={(e) => setNewItem({ ...newItem, name: e.target.value })}
            />
        </div>
        <div className={styles['create__item-category']}>
            <label>Choose the category</label>
            <select value={category} onChange={handleCategoryChange}>
                <option value="">Select a category</option>
                {categories.map((category) => (
                    <option key={category.id} value={category.id}>
                        {category.name}
                    </option>
                ))}
            </select>
        </div>
        <div className={styles["create__item-description"]}>
            <label>Enter a description</label>
            <textarea 
                value={newItem.description} 
                onChange={(e) => setNewItem({ ...newItem, description: e.target.value })}
            />
        </div>
        <div className={styles["create__item-price"]}>
            <label>Enter a price</label>
            <EnterInput 
                type="text"
                value={newItem.price.toString()}
                onChange={(e) => setNewItem({ ...newItem, price: parseFloat(e.target.value) })}             
            />
        </div>
        <div className={styles["create__item-city"]}>
            <label>Enter a city</label>
            <EnterInput 
                type="text"
                value={newItem.city} 
                onChange={(e) => setNewItem({ ...newItem, city: e.target.value })}
            />
        </div>
        <div className={styles["create__item-state"]}>
            <label>Choose the state</label>
            <EnterInput 
                type="text"
                value={newItem.state} 
                onChange={(e) => setNewItem({ ...newItem, state: e.target.value })}
            />
        </div>
        <button className={styles["create__item-button"]} type='submit' onClick={() => handleCreateItem()}>Create</button>
    </div>
  );
};

export default ItemsList;